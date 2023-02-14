using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P011P2023.Controllers
{
    public class DBEquipo
    {
        readonly SQLiteAsyncConnection _connection;

        //Constructor vacio
        public DBEquipo() 
        { }


        public DBEquipo(String dbpath) 
        {
        _connection = new SQLiteAsyncConnection(dbpath);
        //Creacion de objetos de base de datos
        _connection.CreateTableAsync<Models.Equipos>().Wait();

        }

        //CRUD 
        public Task<int> StoreEquipo(Models.Equipos equipo)
        {
            if(equipo.Id== 0) { 
                return _connection.InsertAsync(equipo);
            }
            else
            {
                return _connection.UpdateAsync(equipo);
            }
        }

        //read list
        public Task<List<Models.Equipos>> ListaEquipos()
        {
            return _connection.Table<Models.Equipos>().ToListAsync();
        }


        //get
        public Task<Models.Equipos> GetListaEquipos(int pid)
        {
            return _connection.Table<Models.Equipos>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }


        //delete
        public Task<int> DeleteEquipos(Models.Equipos equipos)
        {
            return _connection.DeleteAsync(equipos);
        }
    }
}
