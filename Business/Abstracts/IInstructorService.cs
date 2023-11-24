using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        IDataResult<List<Instructor>> GetAll();
        IDataResult<Instructor> GetById(int id);
        IResult Add(Instructor instructor);
        IResult Delete(Instructor ınstructor);
        IResult Update(Instructor instructor);
    }
}
