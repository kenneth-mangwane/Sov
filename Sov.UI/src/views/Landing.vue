<template>
    <div>
        <div class="position-relative">
            <!-- shape Hero -->
            <section class="section-shaped my-0">
                <div class="shape shape-style-1 shape-default shape-skew">
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                </div>
                <div class="container shape-container d-flex">
                    <div class="col px-0">
                        <div class="row">
                            <div class="col-lg-6">
                                <h1 class="display-3 text-white">
                                    A beautiful Place to laugh and Chill
                                    <span>get to reading</span>
                                </h1>
                                <p class="lead text-white">See all your favourite  Star wars characters in one place</p>
                                <div class="btn-wrapper">
                                   
                                    <base-button tag="a"
                                                 v-on:click="Subscriptions()"
                                                 class="mb-3 mb-sm-0"
                                                 type="white">Subscriptions</base-button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- 1st Hero Variation -->
        </div>
        <section class="section section-lg pt-lg-0 mt--200">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-12">
                        <div class="row row-grid">
                            <div class="col-lg-4 mt-5" v-for="(item,i) in books" :key="i">
                                <card class="border-0" hover shadow body-classes="py-5 ">
                                    <icon name="ni ni-check-bold"
                                          type="primary"
                                          rounded
                                          class="mb-4"></icon>
                                    <h6 class="text-primary text-uppercase">{{item.name}}</h6>
                                    <p class="description mt-3">
                                        {{item.text.substring(0, 60)}} ...
                                    </p>
                                    <div>
                                        <badge type="success" rounded>R <span>{{item.price}}</span> Per Month</badge>
                                        
                                    </div>
                                    <base-button v-if="!item.subscribed" tag="a"
                                                 v-on:click="subscribe(i)"
                                                 href="#"
                                                 type="primary"
                                                 class="mt-4">Subscribe</base-button>
                                </card>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </section>

    </div>
</template>

<script>
    import { api } from '../../helpers/helpers'

    export default {
        name: "home",
        data() {
            return {
                skip: 0,
                take: 10,
                people: {},
                user: null
            }
        },
        components: {},
        async created() {
            await this.GetBooks()
            this.user = api.getUser()
        },
        methods: {
            Subscriptions() {
                this.$router.push('/profile')

            },
            async subscribe(i) {
                if (this.user) {
                    const result = await api.get(
                        '/subscription/subscribe?userId=' + this.user.id + '&bookId=' + this.books[i].id
                    )
                    if (result) {
                        this.books[i].subscribed = true;
                    }
                }
                else {
                    this.$router.push('/profile')
                }
            },
            async GetBooks() {
                const result = await api.get(
                    '/book/list?take=' + this.take + '&skip=' + this.skip
                )
                if (result && !result.error) {
                    this.books = result.data;
                }

            }
        }
    };
</script>
