using Core.Data_Access.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTeacherDal : EfEntityRepositoryBase<Teacher>, ITeacherDal
    {
        private readonly ExamContext _examContext;
        public EfTeacherDal(ExamContext context) : base(context)
        {
            _examContext = context;
        }
    }
}
