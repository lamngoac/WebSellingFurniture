<template>
    <div class="">
        <div class="h-model-popup"></div>
        <div class="h-popup" :style="{width:width +'px',height: height+'px',top: getHeightScreen/2 - height/2+'px', left : getWidthScreen/2 - width/2+'px'}">
            <div class="h-header h-display-flex">
                <slot name="header"></slot>
                <div class="icon-close icon-16 h-icon-close" @click="clickClosePopup"></div>
            </div>
            <div class="h-content">
                <slot name="content"></slot>
            </div>
            <div class="h-footer h-display-flex">
                <slot name="footer"></slot>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props:{
            /**
             * Chiều rộng popup
             */
            width:{
                typeof:Number,
                default: 500
            },
            /**
             * Chiều cao popup
             */
            height:{
                typeof:Number,
                default: 500
            },

            isShow : {
                default:false,
                typeof:Boolean
            }
        },

        computed:{
            getWidthScreen(){
                return window.innerWidth;
            },
            getHeightScreen(){
                return window.innerHeight;
            },
        },
        methods:{
            clickClosePopup(){
                this.$emit("closePopup");
            }
        }

    }
</script>

<style scoped>
.h-popup{
    position: fixed;
    background: #fff;
    z-index: 1041;
    border-radius: 10px;
    padding: 20px;
}
.h-model-popup{
    position: fixed;
    top: 0px;
    left: 0px;
    width: 100%;
    height: 100%;
    background: #000000;
    opacity: 0.3;
    z-index: 1040;
}
.h-header{
    position: relative;
    height: 30px;
}
.h-icon-close{
    position: absolute;
    right: 0px;
    cursor: pointer;
    box-shadow: 1px 1px #5e5e5e;
}
.h-icon-close:hover{
    box-shadow: 1px 1px #d8d8d3;
}

.h-content{
    height: calc(100% - 70px);
    overflow: auto;
}
.h-content::-webkit-scrollbar {
  width: 5px;
  height: 5px;
}
.h-content::-webkit-scrollbar-track-piece {
  background-color: #c2d2e4;
}
.h-content::-webkit-scrollbar-thumb:vertical {
  height: 30px;
  background-color: #000000;
}

.h-footer{
    position: sticky;
    bottom: 0px;
    left: 0px;
    height: 40px;
}
</style>