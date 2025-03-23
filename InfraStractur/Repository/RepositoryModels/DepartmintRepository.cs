using AutoMapper;
using InfraStractur.Data;
using InfraStractur.Repository.Services;
using Models.DTO;
using Models.Model;
using Models.VM;

namespace InfraStractur.Repository.RepositoryModels
{
    public class DepartmintRepository : RepositoryServicesModels<Departmint, DepartmintSummary, DepartmintDTO>
    {
        private readonly ConnectDataBase context;
        private readonly IMapper mapper;

        public DepartmintRepository(ConnectDataBase context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Departmint> UploadImage(DepartmintDTO departmintDTO)
        {
            if (departmintDTO.img == null || departmintDTO.img.Length == 0)
                return null;

            // الحصول على مسار مجلد wwwroot
            var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var uploadsFolder = Path.Combine(wwwRootPath, "uploads", "DepartminImage");

            // إنشاء المجلد إذا لم يكن موجودًا
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // التحقق من نوع الملف (يمكنك تخصيص الامتدادات المسموح بها)
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(departmintDTO.img.FileName).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
                throw new InvalidOperationException("نوع الملف غير مدعوم!");

            // إنشاء اسم ملف جديد فريد
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            // حفظ الصورة على السيرفر
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await departmintDTO.img.CopyToAsync(stream);
            }

            // حفظ المسار النسبي فقط داخل قاعدة البيانات
            var relativePath = $"/uploads/DepartminImage/{fileName}";

            // تحويل الكائن وإضافة المسار
            var mapping = mapper.Map<Departmint>(departmintDTO);
            mapping.Path = relativePath;

            // حفظ في قاعدة البيانات
            await context.departmints.AddAsync(mapping);
            await context.SaveChangesAsync();

            return mapping;
        }


    }
}
