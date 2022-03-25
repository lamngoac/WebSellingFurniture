<template>
<section>
    <h2>Bình luận</h2>
    <div class="fb-comments" :data-href="'http://'+id+'.com'" data-width="" data-numposts="5"></div>
</section>
</template>

<script>
export default {
    props: {
      id: String,
    },
    created() {
        this.$store.dispatch('FB_Parse')
    }
}
</script>

<style>

</style>
