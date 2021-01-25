<template>
    <div class="radiodiv" >
    <input type="radio" name="roles" v-bind:value="elements.roleId" v-model="currentellement.roleId" class="radio-item" @click="onclick"/>
    <label for="na">{{elements.roleName}}</label>
    </div>
</template>

<script>
export default {
    props:
    {
        elements:
        {
            type: Object
        },
        currentellement:
        {
            type: Object
        }

    },
    data()
    {
        return{
            radioValue: null
        }
    },
    methods:{
        onclick()
        {
            this.$emit('newRole', this.elements.roleId) // change Userrole

        }
    }
}
</script>

<style scoped>
.radio-item {
  display: inline-block;
  color: red !important;
  position: relative;
  padding: 0 6px;
  margin: 10px 0 0;
  border-color: brown !important;
  width: 5em;
  height: 5em;
}

.radiodiv
{
    margin-right: 20px;
     margin: auto;
}
</style>