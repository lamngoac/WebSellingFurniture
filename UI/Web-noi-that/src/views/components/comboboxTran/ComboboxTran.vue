<template>
  <div>
    <div id="ytWidget"></div>
    <script
      type="application/javascript"
      defer
      src="https://translate.yandex.net/website-widget/v1/widget.js?widgetId=ytWidget&pageLang=vi&widgetTheme=light&autoMode=false"
    ></script>
  </div>
</template>

<script>
    export default {
    };
</script>

<style  scoped>

/deep/#yt-widget .yt-servicelink {
  visibility: hidden !important;
}
</style>
