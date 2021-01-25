<template>
     <form class="form-inline" @click="on">
    <li>
            <a>
             <b-iconstack font-scale="1.6">
             <b-icon stacked icon="plus-circle" scale="1" variant="dark"></b-icon>
            </b-iconstack>
            Add user
            </a>
    </li>
    </form>
</template>

<script>
export default {
  data()
  {
    return {

    }
  },
  methods: {
    on()
    {
      this.$emit('add-data');
    }
  }
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
  background: wheat;
  cursor: pointer;
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