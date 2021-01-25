<template>
  <div class="pagnitation">
    <div class="Nav">
        <Pagnitation v-bind:users ="user" @UserInfo = "UserInfo" @addUser="addUser" @newData ="newData" @newClassActive="classActive"/>
    </div>
    <div class="workplace">
      <div class="NavPagn">
        <NavPanel @NavData = "Navdata" v-bind:currentClass="currentClass"/>
      </div>

      <Userinfo v-bind:data="fullUserInformation" v-bind:navdata="Navdatainfo" @changeRefreshUser="changes"/>

      
    </div>
  </div>
</template>

<script>
import Pagnitation from '@/components/Pagnitation.vue'
import NavPanel from '@/components/NavPanel.vue'
import Userinfo from '@/components/UserInfo.vue'
import axios from "axios";

export default {

  components:{
    Pagnitation,
    NavPanel,
    Userinfo
  },
   data() {
        return {
         user: null,
          currentObject: Object,
            fullUserInformation: null,
              Navdatainfo: null, 
              currentClass : true
    }
  },
  methods:{
   async UserInfo(object) // get full info about user
    {
      this.currentObject = object
      let result = await axios({
        url: "http://localhost:50598/api/user/getdatabyid",
        method: "POST",
        headers: {
          'Content-Type': 'application/json',
        },
        data: {id: JSON.stringify(this.currentObject.id)}
      }).then(request => this.fullUserInformation = request.data)
    },

    newData(data) // Push new Data
    {
      this.user = data.data
    },

    classActive(data) // Push new Class
    {
      this.currentClass = data
    },
    
    addUser(data) // add User
    {
      this.user = data
    },

    Navdata(data) // Data for nav
    {
      this.Navdatainfo = data
    },
    changes(data)//Change user
    {
      this.user = data.value
    }
    
  },

      async mounted() // get data for the mainpage
    {
    await axios.get("http://localhost:50598/api/user/showenableuser").then(data => this.user = data.data)
    

    }
}
</script>

<style scoped>
 .pagnitation
 {
   display: flex;
   width: 100vw;
   height: 100vh;
 }

 .Nav
 {
   width: 25vw;
   background: rgb(232,230,232);
 }

 .workplace
 {
   width: 75vw;
    background: rgb(247,246,244);
 }

 .NavPagn
 {
   width: 75vw;
   height: 30px;
   background: darkred;
 }
 .Navbar
 {
    width: 75vw;
    height: 40px;
    background: rgb(119,119,119);
 }

</style>