<template>
    <div class="profile-page">
        <section class="section-profile-cover section-shaped my-0">
            <div class="shape shape-style-1 shape-primary shape-skew alpha-4">
                <span></span>
                <span></span>
                <span></span>
                <span></span>
                <span></span>
                <span></span>
                <span></span>
            </div>
        </section>
        <section class="section section-skew">
            <div class="container">
                <card shadow class="card-profile mt--300" no-body>
                    <div class="px-4">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <h1 class="text-center mt-3">Categories</h1>
                                </div>
                            </div>
                        </div>

                        <div class="mt-5 py-5 border-top text-center">
                            <div class="row justify-content-center">
                                <div class="col-lg-9">
                                    <div class="row justify-content-center">
                                        <div class="col-lg-12">
                                            <div class="row row-grid">
                                                <div
                                                    class="col-lg-4 mt-5"
                                                    v-for="(item, i) in categories"
                                                    :key="i"
                                                >
                                                    <card
                                                        class="border-0"
                                                        hover
                                                        shadow
                                                        body-classes="py-5 "
                                                    >
                                                        <icon
                                                            name="ni ni-check-bold"
                                                            type="primary"
                                                            rounded
                                                            class="mb-4"
                                                        ></icon>
                                                        <h6
                                                            class="text-primary text-uppercase"
                                                        >{{ item }}</h6>

                                                        <base-button
                                                            tag="a"
                                                            v-on:click="ViewJoke(i)"
                                                            href="#"
                                                            type="primary"
                                                            class="mt-4"
                                                        >See Joke</base-button>
                                                    </card>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </card>
            </div>
        </section>
        <modal name="my-first-modal">This is my first modal</modal>
    </div>
</template>
<script>
import { api } from '../../helpers/helpers'

export default {
    data() {
        return {
            skip: 0,
            take: 10,
            user: null,
            categories: []
        }
    },
    components: {},
    async created() {

        await this.GetCategories()
    },
    methods: {

        async ViewJoke(i) {
            this.$modal.show('my-first-modal');

            // if (this.user) {
            //     const result = await api.get(
            //         '/chuck/categories'
            //     )
            //     if (result) {
            //         this.books[i].unsubscribed = true;
            //     }
            // }

        },
        async GetCategories() {
            const result = await api.get(
                '/chuck/categories'
            )
            if (result && !result.error) {
                this.categories = result;
            }

        }
    }

};
</script>
<style>
</style>
