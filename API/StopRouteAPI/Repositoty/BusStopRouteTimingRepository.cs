using Dao;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Repositoty
{
    public class BusStopRouteTimingRepository : IBusStopRouteTimingRepository
    {
        private readonly GMVDBContext _gmvDBContext;
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=srdksql;Database=MyDB";

        public BusStopRouteTimingRepository(GMVDBContext gmvDBContext)
        {
            this._gmvDBContext = gmvDBContext;
        }
        public IEnumerable<BusStopRouteTimes> getDetails(int busStopId)
        {
            List<BusStopRouteTimes> lstBSRTimes = new List<BusStopRouteTimes>();
            try
            {
                var x = _gmvDBContext.busStopRouteTimes.Where(b => b.StopId == busStopId);
                return x;
            }
            catch(Exception ex)
            {

            }

            return null;
        }

        public IEnumerable<BusStops> getBusstopDetails()
        {
            try
            {
                var x = _gmvDBContext.busStops;
                return x;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public List<BusStops> getAllBusStops()
        {
            List<BusStops> busStops = new List<BusStops>();
            try
            {
                var con = new NpgsqlConnection(connectionString);
                con.Open();
                string sql = @"SELECT ""Id"",""Name"" FROM public.""BusStops""";

                var cmd = new NpgsqlCommand(sql, con);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    BusStops bs = new BusStops();
                    bs.Id = Convert.ToInt32(rdr[0]);
                    bs.Name = Convert.ToString(rdr[1]);
                    busStops.Add(bs);
                    bs = null;
                }

                return busStops;
            }
            catch(Exception ex)
            {

            }

            return null;
        }

        public List<BusStopRouteTimes> getAllRoutesBasedonBusStops(int id)
        {
            List<BusStopRouteTimes> busStopRouteTimes = new List<BusStopRouteTimes>();
            try
            {
                var con = new NpgsqlConnection(connectionString);
                con.Open();
                string sql = @"SELECT ""RouteId"",""StartTime"",""StopId"", BS.""Name"" As BusStop, RE.""Name"" As Route FROM public.""BusStopRouteTimes"" BSRT inner join ";
                       sql = sql + @" public.""BusStops"" BS on BSRT.""StopId"" = BS.""Id""";
                sql = sql + @" inner join  public.""Routes"" RE on BSRT.""RouteId"" = RE.""Id""";
                sql = sql + @" where ""StopId"" =" + id + " and  ";
                sql = sql + @" ""StartTime"" >= now()::time and ""StartTime"" <= now()::time + INTERVAL '45 min'";
                sql = sql + @" GROUP BY ""RouteId"", ""StartTime"",""StopId"", BS.""Name"", RE.""Name""";

                var cmd = new NpgsqlCommand(sql, con);

                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    BusStopRouteTimes bsrt = new BusStopRouteTimes();
                    bsrt.RouteId = Convert.ToInt32(rdr[0]);
                    bsrt.StartTime = Convert.ToString(rdr[1]);
                    bsrt.StopId = Convert.ToInt32(rdr[2]);
                    bsrt.BusStop = Convert.ToString(rdr[3]);
                    bsrt.Route = Convert.ToString(rdr[4]);

                    busStopRouteTimes.Add(bsrt);
                    bsrt = null;
                }

                return busStopRouteTimes;
            }
            catch (Exception ex)
            {

            }

            return null;
        }




        public void getBusstopNonEFDetails()
        {
            List<BusStopRouteTimes> bsrTimes = new List<BusStopRouteTimes>();
            try
            {
                

                var con = new NpgsqlConnection(connectionString);
                con.Open();

                string sqlP = @"call public.select_busstops()";

               

                var cmd1 = new NpgsqlCommand(sqlP, con);
                
                NpgsqlDataReader rdr1 = cmd1.ExecuteReader();

                while (rdr1.Read())
                {
                    Routes rt = new Routes();
                    var m = rdr1[0];
                    var x = rdr1[1];
                    //rt.Details = rdr.GetString(2);

                }
            }
            catch (Exception ex)
            {

            }

            
        }
    }
}

