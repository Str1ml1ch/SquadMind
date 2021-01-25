<template>
    <b-nav pills class="Navbar">
    <b-nav-item v-bind:class="[currentAction=='Profile'  ? 'active' : '']" @click="onClick('Profile')">Profile</b-nav-item>
    <b-nav-item v-bind:class="[currentAction=='User Role' ? 'active' : '']" @click="onClick('User Role')">User Role</b-nav-item>
    <b-nav-item v-bind:class="[currentAction=='Settings' ? 'active' : '']" @click="onClick('Settings')">Settings</b-nav-item>
  </b-nav>
</template>

<script>
export default {
    props:{
        isProfile:
        {
          type:String
        }
    },
    data()
    {
        return{
          currentAction : null
        }
    },
    methods:
    {
      onClick(data)
      {
        this.$emit('NavData',data)
        this.currentAction = data
      }
    },

    mounted()
    {
      this.currentAction = "Profile"
      this.$emit('NavData',this.currentAction)
    }
}
</script>


<style scoped>
  li a
  {
    color: white;
  }

  .router-link-active
  {
    background: darkslategray;
  }

  .active {
  cursor: pointer;
  text-decoration: underline;
}

ul
{
    text-align: center;
}

li
{
  margin-right: auto;
  margin-left: auto;
}

</style>