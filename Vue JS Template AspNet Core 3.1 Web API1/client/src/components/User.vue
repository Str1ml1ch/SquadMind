<template>
 <form class="form-inline" @click="submit">
    <li>
            <router-link v-bind:to = "path">
             <b-iconstack font-scale="1.6">
            <b-icon stacked icon="circle-fill" variant="dark"></b-icon>
             <b-icon stacked icon="person-circle" scale="0.4" variant="white"></b-icon>
            </b-iconstack>
            {{user.name}} {{user.lastName}}
            </router-link>
    </li>
    </form>
</template>



<script>

export default {
    props:
    {
        user: {
            type: Object,
            required: true
        }
    },
    
    data()
    {
        return {
            path : `/user/${this.user.id}`,
            loading: true
        }
    },
    methods:{
       submit()
        {
            console.log(this.user)
            this.$emit("currentUser",this.user)
        }
    },
}
</script>

<style scoped>
li a {
  display: block;
  color: black;
  font-family:'Poppins', sans-serif;
  padding: 8px 16px;
  text-decoration: none;
  text-align: left;
}

.router-link-active
{
    background-color: rgb(119,119,119);
    color: black;
}

li a:hover:not(.active) {
  background-color: #555;
  color: white;
}

form
{
    display: inline;
}

.describe
{
    font-family:'Poppins', sans-serif;
}
</style>