<template>
    <section class="section section-shaped section-lg my-0">
        <div class="shape shape-style-1 bg-gradient-default">
            <span></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
            <span></span>
        </div>
        <div class="container pt-lg-md">
            <div class="row justify-content-center">
                <div class="col-lg-5">
                    <card type="secondary" shadow
                          header-classes="bg-white pb-5"
                          body-classes="px-lg-5 py-lg-5"
                          class="border-0">

                        <template>
                            <div class="text-center text-muted mb-4">
                                <small>Sign up with credentials</small>
                            </div>
                            <form role="form">
                                <base-input alternative
                                            v-model="user.firstName"
                                            class="mb-3"
                                            placeholder="Name"
                                            addon-left-icon="ni ni-hat-3">
                                </base-input>
                                <base-input alternative
                                            v-model="user.lastName"
                                            class="mb-3"
                                            placeholder="Last Name"
                                            addon-left-icon="ni ni-hat-3">
                                </base-input>
                                <base-input alternative
                                            v-model="user.email"
                                            class="mb-3"
                                            placeholder="Email"
                                            addon-left-icon="ni ni-email-83">
                                </base-input>
                                <base-input alternative
                                            v-model="user.password"
                                            type="password"
                                            placeholder="Password"
                                            addon-left-icon="ni ni-lock-circle-open">
                                </base-input>


                                <div class="text-center">
                                    <base-button type="primary" v-on:click="register" class="my-4">Create account</base-button>
                                </div>
                            </form>
                        </template>
                    </card>
                </div>
            </div>
        </div>
    </section>
</template>
<script>
    import { api } from '../../helpers/helpers'

    export default {
        data() {
            return {
                user: {
                    firstName: null,
                    lastName: null,
                    email: null,
                    password: null

                }

            }
        },
        components: {},
      
        methods: {
            async register() {
                var result = await api.post("/user/register", this.user)
                if (result && !result.error) {
                    api.saveUser(result.data);
                    this.$router.push('/profile')

                }
                else {
                    alert("Unable to Complete registration")
                }
            }
        }
    };
</script>
<style>
</style>
