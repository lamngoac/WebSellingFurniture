<template>
<div>
    <TheHeader />
    <TheContent />
    <TheFooter />
</div>
</template>

<script>
import TheContent from '@/components/TheContent'
import TheHeader from '@/components/TheHeader'
import TheFooter from '@/components/TheFooter'
export default {
    components: {
        TheHeader,
        TheContent,
        TheFooter
    },
    created(){
    },
    mounted(){
    }
}
</script>

<style scoped>

</style>
