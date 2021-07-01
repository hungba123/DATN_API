﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sohuudetaiController : ControllerBase
    {
        [Route("get_sohuudetai_pagesize")]
        [HttpGet]
        public datatable<Tblsohuudetai> get_sohuudetai_pagesize(int pagesize, int pageindex, string search)
        {
            datatable<Tblsohuudetai> dv = new datatable<Tblsohuudetai>();
            List<Tblsohuudetai> ds = new List<Tblsohuudetai>();
            using (sql_NCKHContext db = new sql_NCKHContext())
            {
                int index = (pageindex - 1) * pagesize;
                ds = db.Tblsohuudetais.Skip(pageindex).Take(pagesize).ToList();
                dv.total = db.Tblsohuudetais.Count();
                dv.result = ds;
            }
            return dv;
        }
        [Route("get_sohuudetai_iddetai/{iddetai}")]
        [HttpGet]
        public List<sohuu> get_sohuudetai_iddetai(int iddetai)
        {
            using (sql_NCKHContext db = new sql_NCKHContext())
            {
                return db.Tblsohuudetais.Join(db.Tblsohuus, dt => dt.Idsohuu, sh => sh.Id, (dt, sh) => new sohuu
                {
                    Id = dt.Id,
                    Iddetai = dt.Iddetai,
                    Idsohuu = dt.Idsohuu,
                    Ghichu = dt.Ghichu,
                    Tensohuu = sh.Tensohuu
                }).Where(x => x.Iddetai == iddetai).ToList();
            }
        }
        [Route("get_sohuudetai_id/{id}")]
        [HttpGet]
        public Tblsohuudetai get_sohuudetai_id(int id)
        {
            Tblsohuudetai dv = new Tblsohuudetai();
            using (sql_NCKHContext db = new sql_NCKHContext())
            {
                dv = db.Tblsohuudetais.SingleOrDefault(x => x.Id == id);
            }
            return dv;
        }
        [Route("create_sohuudetai")]
        [HttpPost]
        public alter create_sohuudetai([FromBody] List<Tblsohuudetai> sh)
        {
            alter al = new alter();
            try
            {
                if(sh.Count() == 0)
                {
                    al.ketqua = false;
                    al.thongbao = "Không để rỗng";
                    return al;
                }
                using (sql_NCKHContext db = new sql_NCKHContext())
                {
                    int dem = 0;
                    foreach(var item in sh)
                    {
                        Tblsohuudetai result = db.Tblsohuudetais.SingleOrDefault(x => x.Iddetai == item.Iddetai && x.Idsohuu == item.Idsohuu);
                        if (result ==null)
                        {
                            Tblsohuudetai a = new Tblsohuudetai();
                            a.Iddetai = item.Iddetai;
                            a.Idsohuu = item.Idsohuu;
                            db.Tblsohuudetais.Add(a);
                            db.SaveChanges();
                        }
                        else
                        {
                            dem++;
                        }
                    }
                    al.ketqua = true;
                    al.thongbao = string.Format("Thêm thành công {0}, lỗi {1} ", sh.Count() - dem, dem);
                     return al;
                }
            }
            catch (Exception ex)
            {
                al.ketqua = false;
                al.thongbao = ex.Message;
                return al;
            }
        }
        [Route("edit_sohuudetai/{id}")]
        [HttpPut]
        public bool edit_sohuudetai(int id, [FromBody] Tblsohuudetai sh)
        {
            try
            {
                using (sql_NCKHContext db = new sql_NCKHContext())
                {
                    Tblsohuudetai d = db.Tblsohuudetais.SingleOrDefault(x => x.Id == id);
                    if (string.IsNullOrEmpty(d.ToString()))
                        return false;
                    d.Idsohuu = sh.Idsohuu;
                    d.Ghichu = sh.Ghichu;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        [Route("delete_sohuudetai/{id}")]
        [HttpDelete]
        public bool delete_sohuudetai(int id)
        {
            try
            {
                using (sql_NCKHContext db = new sql_NCKHContext())
                {
                    Tblsohuudetai d = db.Tblsohuudetais.SingleOrDefault(x => x.Id == id);
                    if (string.IsNullOrEmpty(d.ToString()))
                        return true;
                    db.Tblsohuudetais.Remove(d);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
