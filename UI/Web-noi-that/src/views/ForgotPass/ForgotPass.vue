<template>
<div class="bg-login">
    <div class="text-h">
        <div class="text-home" @click="redirectHome">
            Trang chủ
        </div>
    </div>
    <div class="h-login">
        <a-form id="components-form-demo-normal-login" :form="form" class="login-form" @submit="handleSubmit">
            <a-form-item>
                <div class="text-login">
                    Quên mật khẩu
                </div>
            </a-form-item>
            <a-form-item>
                <a-input v-decorator="[
                'UserName',
                { rules: [{ required: true, message: 'Vui lòng nhập tên tài khoản! Tài khoản không được để chống' }] },
                ]" placeholder="Tài khoản">
                    <a-icon slot="prefix" type="user" style="color: rgba(0,0,0,.25)" />
                </a-input>
                <div class="text-error-username" v-if="!checkExistUserName">
                    Tài khoản không tồn tại !
                </div>
            </a-form-item>
            <a-form-item style="margin-top:15px">
                <div v-if="isSuccess" class="text-success">
                  Lấy lại mật khẩu thành công! Mật khẩu mới của bạn là : {{ newPass }}
                </div>
                <div class="btn-login">
                    <a-button type="primary" html-type="submit" class="login-form-button font-bold">
                        Quên mật khẩu
                    </a-button>
                </div>
                <div class="font-bold">
                    <router-link class="h-router-link" to="/login">
                        Đăng nhập ngay
                    </router-link>
                </div>
            </a-form-item>
        </a-form>
    </div>
</div>
</template>

<script>
import {
    mapActions
} from "vuex";
import {
    ModuleUser
} from "@/store/module-const";

export default {

    beforeCreate() {
        this.form = this.$form.createForm(this, {
            name: 'normal_login'
        });
    },
    data() {
        return {
            checkExistUserName: true,
            users: [],
            isSuccess : false,
            newPass : ""
        }
    },
    async created() {
        const me = this;
        let res = await me.getUsers();
        if (res) {
            me.users = [...res];
        }
    },
    methods: {
        ...mapActions(ModuleUser, ["getUsers","editUserAsync","getUserByUserName"]),
        async handleSubmit(e) {
            e.preventDefault();
            this.form.validateFields( async (err, values) => {
                const me = this;
                if (!err) {
                    let user = await me.getUserByUserName(values.UserName);
                    if(user){
                        // random pass
                        let pas =  (Math.random() + 1).toString(36).substring(4);
                        user.password = pas;
                        me.newPass = pas;
                        await me.editUserAsync(user); 
                        me.isSuccess = true;
                        me.form.resetFields();
                    }
                    else{
                        me.isSuccess = false;
                        me.checkExistUserName = false;
                    }
                }
                else{
                    me.checkExistUserName = true;
                }
            });
        },
        redirectHome(){
            this.$router.push('/');
        }
    },
};
</script>

<style scoped>
.bg-login {
    background: url('https://cdn.pixabay.com/photo/2019/01/16/06/12/furniture-3935398_1280.jpg');
    width: 100%;
    height: 100vh;
}
.text-h{
    padding: 10px;
}
.text-home{
    font-size: 18px;
    color:#fff;
    border-radius: 4px;
    background: #1890ff;
    box-shadow: 1px 1px #e5e5e5;
    width: 100px;
    text-align: center;
    cursor: pointer;
}
.h-login {
    width: 100%;
    justify-content: center;
    padding: 200px 500px 0 500px;
}

.text-login {
    font-size: 22px;
    font-weight: bold;
    text-align: center;
}

.text-error-username,
.text-error-password {
    color: red;
}

#components-form-demo-normal-login .login-form-forgot {
    float: right;
}

.btn-login {
    display: flex;
    justify-content: flex-end;
}

#components-form-demo-normal-login .login-form-button {
    width: 150px;
}

.h-router-link{

}
.h-router-link:hover{
    color: #1890ff;
}
.text-success{
  color: green;
}
</style>
