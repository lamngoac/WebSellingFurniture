<template>
<div :class="classCombobox">
    <div v-if="title" :class="classTitle">{{title}}</div>
    <a-select show-search option-filter-prop="children" :style="styleCombo" style="width: 200px" :filter-option="filterOption" @focus="handleFocus" @blur="handleBlur" @change="handleChange" :placeholder="placeholder" :value="value ? value : null">
        <a-select-option v-for="(item,index) in data" :key="index" :value="item[`${keyData}`]">
            {{ item[`${display}`] }}
        </a-select-option>
    </a-select>
</div>
</template>

<script>
export default {
    props:{
        data:[],
        keyData:{
            typeof:String,
            default:"",
        },
        display :{
            typeof:String,
            default:"",
        },
        defaultValue : {},
        value:{},
        title:{
            typeof:String,
            default:"",
        },
        classCombobox:{
            typeof:String,
            default:""
        },
        placeholder :{
            typeof:String,
            default:""
        },
        styleCombo:{},
        classTitle:{
            typeof:String,
            default:""
        },
    },
    data(){
        return{}
    },
    methods: {
        handleBlur() {},
        handleFocus() {},
        filterOption(input, option) {
            return (
                option.componentOptions.children[0].text
                .toLowerCase()
                .indexOf(input.toLowerCase()) >= 0
            );
        },
        handleChange(value){
            const me = this;
            me.$emit("changeCombobox",value);
        },
    },
};
</script>

<style lang="scss" scoped>
</style>
