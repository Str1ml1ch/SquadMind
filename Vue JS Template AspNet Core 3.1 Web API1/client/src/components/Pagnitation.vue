<template>
<div >
    <ul v-if="users">
        <AddUSer @add-data = "addUser"/>
        <div>
          <b-form-input size="sm" class="inputers" placeholder="Search"  @input="someHandler" v-model="searchtext" ></b-form-input>
        </div>
        <button @click="Sordata(true)" v-bind:class ="[isActive ? 'active' : '']">Enabled</button>
        <button @click="Sordata(false)" v-bind:class ="[isActive ? '' : 'active']">Disabled</button>
        <Element v-bind:user = "peoples" v-for="peoples in users" :key="peoples.id" @currentUser="currentUser"/>
</ul>
  <Loader v-else class="loader"/>
</div>
</template>


<script>
import Element from './User'
import AddUSer from './AddUser.vue'
import Loader from './Spinner'
import axios from 'axios'

export default {
    props: {
      users: {
        type: Array
      },
      newClassActive:{
        type: Boolean
      }
    },
  components: {
    Element,
    AddUSer,
    Loader
  },
  methods:{
    currentUser(object)
    {
      this.$emit('UserInfo',object)
    },

  async Sordata(data) // sort data by Enable/Disable
  {
    if(data === false)
    {
    await axios({
      url: "http://localhost:50598/api/user/showenableuser",
      method: "POST"
    }).then(data => this.$emit('newData',data)).then(this.isActive = data)
    }
    if(data === true)
    {
      await axios({
      url: "http://localhost:50598/api/user/showdisableuser",
      method: "POST"
    }).then(data => this.$emit('newData',data)).then(this.isActive = data)
    }
  },

    async addUser() // Add new User
    {
      await axios.post("http://localhost:50598/api/user/addnewuser").then(data => this.$emit("addUser",data.data))
    },
    async someHandler() // search User by data
    {
            let result = await axios({
        url: "http://localhost:50598/api/user/searchuser",
        method: "POST",
        headers: {
          'Content-Type': 'application/json',
        },
        data: {data: this.searchtext}
      })
      this.users = result.data
    }
  },


  data()
  {
    return{
      searchtext: '',
      isEnable: true,
      isActive: true
    }
  }

}
</script>


<style scoped>
button{
  border: none;
  width: 50%;
  height: 20px;
  background: none;
}
ul {
 
  list-style-type: none;
  margin: 0;
  padding: 0;
  position: fixed;
  height: 100%;
  overflow: auto;
  width: 25vw;
}

.loader
{
  margin-left: auto;
    margin-right: auto;
}
</style>