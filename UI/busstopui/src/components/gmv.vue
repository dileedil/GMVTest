<template>
  <div id="gmv">
        <h1>GMV Bus Route System</h1>    
        </br>
        <div>
                <b-row>
                        <b-col sm="3" align=right >
                        Select a Bus Stop : 
                        </b-col>
                        <b-col sm="1">
                        </b-col>
                        <b-col sm="6">
                        <b-form-select id="bsL" v-model="busStopId"  >
                                <b-form-select-option v-for="item in busstoplist" v-bind:key="item.id"  :value="item.id" >{{item.name}}</b-form-select-option>
                        </b-form-select>
                        </b-col>
                        <b-col sm="2">
                        </b-col>
                </b-row>
        </div>
        <div>
                </br>
        </div>
      
       <div>

                        <b-button id="btnBSRTimes" @click="LoadBusStopsRouteTimes" variant="success" >Bus Stops Route Times</b-button>
        </div>

        <div>
                </br>
        </div>

        <div>
               <b-row>
                        <b-col sm="1">
                        </b-col>
                        <b-col sm="10">
                                <b-table striped hover :items="busstopRouteTimelist"  id="brTimes"     :per-page=25 :current-page=1 :fields="column" show-empty >
                                </b-table>
                        </b-col>
                        <b-col sm="1">
                        </b-col>
             </b-row>

                        
        </div>
        <div>
                </br>
        </div>
        

  </div>
</template>

<script lang="ts">
import Vue from 'vue'
import {Component} from 'vue-property-decorator';
import busstopservice from "../services/busstopservice";
import busstopRTservice from "../services/busstoproutetimeservice";

@Component({
    })
export default class gmv extends Vue{
  
  private busStopId: number = 1;
  private busstoplist: any[] = [];
  private selectedBusStop: number = 0;
  private busstopRouteTimelist: any[] = [];
   
  

  column = [
         
           {
                  key: "busStop",
                  label : "Bus Stop",
                  sortable : true
          },
           {
                  key: "route",
                  label : "Route",
                  sortable : true
          },
           {
                  key: "startTime",
                  label : "Start Time",
                  sortable : true
          },
  ];

  retriveInitialRequiredData()
  {
       
        return busstopservice.getAll().then((response) => {
                if(response){
                        console.log("Bus Stop List", response.data);
                        this.busstoplist = response.data;
                       // this.temp = response.data;
                       // console.log("busstoplist", this.busstoplist);
                }
        }
        );
        
  }

  mounted()
  {
        
          this.retriveInitialRequiredData();
          
  }



LoadBusStopsRouteTimes()
{
        return busstopRTservice.get(this.busStopId).then((response) => {
        if(response){
                console.log("Bus Stop Route Times List", response.data);
                this.busstopRouteTimelist = response.data;
                console.log("busstopRouteTimelist", this.busstopRouteTimelist);
        }
        }
        );  
        
        this.selectedBusStop = 60;
}
    
}
</script>

<style scoped>

</style>