using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentBillsAPI.Data;
using StudentBillsAPI.Models;

namespace StudentBillsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentBillController : Controller
    {
        private readonly StudentBillAPIDbContext dbContext;
        public StudentBillController(StudentBillAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentBills()
        {
            return Ok(await dbContext.StudentBills.ToListAsync());
        }

        [HttpPost]

        public async Task<IActionResult> AddStudentBill(AddNewBill addnewbill)
        {
            var student = new StudentBill
            {
                Id = Guid.NewGuid(),
                FullName = addnewbill.FullName,
                Phone = addnewbill.Phone,
                Email = addnewbill.Email,
                Bill = addnewbill.Bill
            };

            await dbContext.StudentBills.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateStudentBill([FromRoute]Guid id,UpdateBill updatebill)
        {
            var student=await dbContext.StudentBills.FindAsync(id);

            if (student != null)
            {
                student.FullName = updatebill.FullName;
                student.Phone = updatebill.Phone;   
                student.Email = updatebill.Email;
                student.Bill = updatebill.Bill;

              await dbContext.SaveChangesAsync();

                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetStudentBill([FromRoute]Guid id)
        {
            var student = await dbContext.StudentBills.FindAsync(id);

            if (student == null) 
            { 
             return NotFound();
            }
            else
            {
                return Ok(student);
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteStudentBill([FromRoute] Guid id)
        {
            var student = await dbContext.StudentBills.FindAsync(id);

            if (student != null)
            {
                dbContext.Remove(student);
                await dbContext.SaveChangesAsync();
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }
    }
  }

