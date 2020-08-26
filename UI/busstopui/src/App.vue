<template>
  <div id="app">
    
    <GMV />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import {BootstrapVue} from 'bootstrap-vue'
import HelloWorld from './components/HelloWorld.vue';
import GMV from './components/gmv.vue';
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(BootstrapVue)

@Component({
  components: {
    HelloWorld,
    GMV
  },
})
export default class App extends Vue {}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
