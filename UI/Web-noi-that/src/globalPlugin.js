import Vue from 'vue';
import moment from 'moment'

import commonFunc from '@/common/common.js'
import Enum from '@/enum/enum';

import Input from '@/views/components/input/Input';
import InputDate from '@/views/components/inputDate/InputDate';
import inputFile from '@/views/components/inputFile/InputFile';
import Popup from '@/views/components/popup/Popup';
import Textarea from '@/views/components/textarea/Textarea';
import Pagination from "@/views/components/pagination/Pagination";
import Radio from '@/views/components/radio/Radio';
import Checkbox from "@/views/components/checkbox/Checkbox";
import Combobox from "@/views/components/combobox/Combobox";
import Grid from "@/views/components/grid/Grid";
import ComboboxTran from "@/views/components/comboboxTran/ComboboxTran"; 
const install = Vue => {
    //prototype
    Vue.prototype.moment = moment
    Vue.prototype.$commonFunc = commonFunc;
    Vue.prototype.$enum = Enum;

    //components
    Vue.component('h-input',Input);
    Vue.component('h-input-date',InputDate);
    Vue.component('h-input-file',inputFile);
    Vue.component('h-popup',Popup);
    Vue.component('h-textarea',Textarea);
    Vue.component('h-pagination',Pagination);
    Vue.component('h-radio',Radio);
    Vue.component('h-checkbox',Checkbox);
    Vue.component('h-combobox',Combobox);
    Vue.component('h-grid',Grid);
    Vue.component('h-combobox-tran',ComboboxTran);
    
};
install(Vue);
export default install;
