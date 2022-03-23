<template>
    <header class="header-global">
        <base-nav class="navbar-main" transparent type="" effect="light" expand>
            <router-link slot="brand" class="btn btn-neutral btn-icon mr-lg-5" to="/">

                <span class="btn-inner--icon">
                    <i class="fa fa-home mr-2"></i>
                </span>
                <span class="nav-link-inner--text">Home</span>
            </router-link>
    <form>
        <div class="form-group mt-3">
            <input class="form-control w-100" style="width: 400px !important"  placeholder="search"/>
        </div>
    </form>



        </base-nav>
    </header>
</template>
<script>
import BaseNav from "@/components/BaseNav";
import BaseDropdown from "@/components/BaseDropdown";
import CloseButton from "@/components/CloseButton";
import Inputs from "../views/components/Inputs.vue";

export default {
  components: {
    BaseNav,
    CloseButton,
    BaseDropdown,
    Inputs
}
};
</script>
<style>
</style>
