<template>
    <div>
        <div class="h-input">
            <div v-if="title" class="h-mb-5 text-title">{{ title }}</div>
            <input ref="input" class="input" type="text" v-bind="$attrs" v-on="inputListeners">
            <div v-if="icon" :class="icon" class="h-icon-input"></div>
        </div>
    </div>
</template>

<script>
    export default {
        props:{
            icon:{
                typeof:String,
                default:""
            },
            title:{
                typeof:String,
                default:""
            }
        },
        computed: {
            inputListeners: function () {
            var vm = this
            // `Object.assign` merges objects together to form a new object
            return Object.assign({},
                // We add all the listeners from the parent
                this.$listeners,
                // Then we can add custom listeners or override the
                // behavior of some listeners.
                {
                // This ensures that the component works with v-model
                input: function (event) {
                    vm.$emit('input', event.target.value)
                }
                }
            )
            }
        },
    }
</script>

<style scoped>
.h-input{
    position: relative;
    box-sizing: border-box;
    
}
.input{
    border: 1px solid #e5e5e5;
    border-radius: 4px;
    padding-left: 10px;
}
.h-icon-input{
    position: absolute;
    top: 8px;
    right: 10px;
}
.text-title{
    font-weight: bold;
}
</style>