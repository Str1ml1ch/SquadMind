<template>
<div class="settings">
    <input class="apple-switch" type="checkbox" v-model="rolesettings.isEnable" v-bind:class ="[rolesettings.settings.isEnable ? 'active' : '']">
        <label for="nn">{{rolesettings.settings.settingsName}}</label>
    </div>
</template>

<script>
export default {
    props:
    {
        rolesettings:
        {
            type: Object
        }
    },
}
</script>


<style scoped>
input.apple-switch {
position: relative;
appearance: none; outline: none;
width: 50px; 
height: 30px;
background-color: #ffffff; 
border: 1px solid #D9DADC;
border-radius: 50px; 
box-shadow: inset -20px 0 0 0 #ffffff;
transition-duration: 200ms;
}

input.apple-switch:after {
content: "";
position: absolute;
top: 1px; left: 1px;
width: 26px; height: 26px;
background-color: transparent;
border-radius: 50%; box-shadow: 2px 4px 6px rgba(0,0,0,0.2);
}

.active
{
    border-color: #4ED164;
box-shadow: inset 20px 0 0 0 #4ED164;
}

input.apple-switch:checked {
border-color: #4ED164;
box-shadow: inset 20px 0 0 0 #4ED164;
}

input.apple-switch:checked:after {
left: 20px;
box-shadow: -2px 4px 3px rgba(0,0,0,0.05);
}

.settings
{
    margin-right: auto;
    margin-left: auto;
    text-align: center;
}
label
{
    vertical-align: bottom;
}
</style>