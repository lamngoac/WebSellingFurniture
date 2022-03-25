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
                    Đăng ký
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
                    Tài khoản đã tồn tại
                </div>
            </a-form-item>
            <a-form-item>
                <a-input-password v-decorator="[
                'Password',
                { rules: [{ required: true, message: 'Vui lòng nhập mật khẩu! Mật khẩu không được để chống!' }] },
                ]" type="password" placeholder="Mật khẩu">
                    <a-icon slot="prefix" type="lock" style="color: rgba(0,0,0,.25)" />
                </a-input-password>
            </a-form-item>
            <a-form-item>
                <a-input v-decorator="[
                'FullName',
                { rules: [{ required: true, message: 'Vui lòng nhập Họ tên! Họ tên không được để chống!' }] },
                ]" placeholder="Họ và tên">
                    <a-icon slot="prefix" type="user" style="color: rgba(0,0,0,.25)" />
                </a-input>
            </a-form-item>
            <a-form-item>
                <a-input v-decorator="[
                'Address',
                { rules: [{ required: true, message: 'Vui lòng nhập Địa chỉ! Địa chỉ không được để chống!' }] },
                ]" placeholder="Địa chỉ">
                    <a-icon slot="prefix" type="address" style="color: rgba(0,0,0,.25)" />
                </a-input>
            </a-form-item>
            <a-form-item>
                <a-input v-decorator="[
                'PhoneNumber',
                { rules: [{ required: true, message: 'Vui lòng nhập Số điện thoại! Số điện thoại không được để chống!' }] },
                ]"  placeholder="Số điện thoại">
                    <a-icon slot="prefix" type="phonenumber" style="color: rgba(0,0,0,.25)" />
                </a-input>
            </a-form-item>
            <a-form-item style="margin-top:15px">
                <div v-if="isSuccess" class="text-success">
                  Đăng ký thành công
                </div>
                <div class="btn-login">
                    <a-button type="primary" html-type="submit" class="login-form-button font-bold">
                        Đăng ký
                    </a-button>
                </div>
                <div>
                    <router-link class="h-router-link login-form-forgot font-bold" to="/forgotpass">
                        Quên mật khẩu
                    </router-link> 
                </div>
                <div class="font-bold">
                    Hoặc
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
            remmber: false,
            checkExistUserName: true,
            users: [],
            isSuccess : false,
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
        ...mapActions(ModuleUser, ["getUsers","addUserAsync"]),
        async handleSubmit(e) {
            e.preventDefault();
            this.form.validateFields( async (err, values) => {
                const me = this;
                if (!err) {
                    // Check tài khoản
                    if (me.users && me.users.length > 0) {
                        // Lấy danh sách user có tài khoản là tài khoản người dùng nhập
                        let accountUsers = [...me.users.filter(item => {
                            if (item.userName == values.UserName) {
                                return true;
                            }
                            return false;
                        })];
                        // Lấy danh sách user có mật khẩu là người dùng nhập
                        if (accountUsers && accountUsers.length > 0) {
                            // tài khoản đã tồn tại
                            me.checkExistUserName = false;
                            
                        }
                        // Tạo thành công 
                        else {
                            me.checkExistUserName = true;
                            me.isSuccess = true;
                            let params = {
                              UserName : values.UserName,
                              Password : values.Password,
                              FullName : values.FullName,
                              Address : values.Address,
                              PhoneNumber : values.PhoneNumber
                            }
                            
                            await me.addUserAsync(params);
                            me.form.resetFields();
                        }
                    }
                    // Lỗi server
                    else {
                        console.log("call api lỗi");
                    }
                } else {
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
