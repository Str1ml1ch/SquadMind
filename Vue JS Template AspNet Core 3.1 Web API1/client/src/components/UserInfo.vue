<template>
    <div class="new">
                <div class="field-image">
               <img v-bind:src="data.user.image">
            </div>
        <form @submit.prevent="save" class="inputforms" v-if="navdata=='Profile'"> 
                <div class="field">
               <label for="n">Name:</label><b-form-input type="text" v-model="data.user.name" class="inputers" />
                </div>
                <div class="field">
                <label for="n">Surname:</label> <b-form-input type="text" v-model="data.user.lastName" class="inputers"/>
                </div>
                <div class="field">
               <label for="n">Skype:</label> <b-form-input type="text" v-model="data.user.skype" class="inputers"/>
                </div>
                <div class="field">
                <label for="n">Email:</label> <b-form-input type="email" v-model="data.user.email" class="inputers"/>
                </div>
                <div class="field">
                <label for="n">Signature:</label> <b-form-input type="text" v-model="data.user.signature" class="inputers"/>
                </div>
                <div class="field">
                <b-button type="submit" class="btn">Save</b-button>
                </div>
        </form>
        <form @submit.prevent="save" v-if="navdata=='User Role'" class="form-inline radioform">
               <Radio v-bind:currentellement="data.user.role" v-bind:elements="datas" v-for="datas in data.role" :key="datas.roleId" @newRole="RoleSave"/>
                <div>
                    <br/>
                <b-button type="submit" class="btn">Save</b-button>
                </div>
        </form>
                <form @submit.prevent="save" v-if="navdata=='Settings'" class="inputforms">
               <Settings v-bind:rolesettings="roleset" v-for="roleset in data.user.roleSettingses" :key="roleset.roleId"/>
                <div class="field">
                <b-button type="submit" class="btn">Save</b-button>
                </div>
        </form>
    </div>
</template>


<script>
import axios from 'axios'
import Radio from './Radiobuttons'
import Settings from './SerringsComponent'

export default {
    props:{
        data:{
            type: Object
        },
        navdata:
        {
            type: String
        }
    },
    methods:
    {
        async save()//save new user data
        {
          let data = await  axios({
                method: "POST",
                url: "http://localhost:50598/api/user/changeuser",
                data: this.data.user,
                        headers: {
                            'Content-Type': 'application/json',
                                },
            }).catch(err => 
            {
                alert(err.response.data.Message)
                })

                

            this.$emit("changeRefreshUser",data.data);
            this.$emit("newClassActive", this.data.user.roleSettingses[0].isEnable);


        },
        RoleSave(data)
        {
            this.data.user.roleIdenty = data;
        }
    },
    components:{
        Radio,
        Settings
    },

    data()
    {
        return{
            user : ''
        }
    }

    

}
</script>

<style scoped>
.new
{
    padding-top: 20px;
}

input {
    background: rgb(247,246,244);
  font-size: 16px;
  display: block;
  border: none;
  border-bottom: 1px solid #ccc;
}
input:focus {
  outline: none;
  background: rgb(247,246,244);
}

@media (min-width: 576px)
{
.form-inline
{
    width: 75%;
}
.inputforms
{
    flex-flow: row;
    width: 50vw;
    margin-left: auto;
    margin-right: auto;
    text-align: left;
    clear: both;
}
.form-control{width: 90%;}
.inputers {float: right}
.field {clear:both; text-align:right; padding: 10px;}
label {float:left;}
}
.radioform
{
    width: 75vw;
}
img
{
    width: 200px;
}
.field-image
{
    text-align: center;
    height: 200px;
}
</style>