using System;
using System.Data;

/// <summary>
/// Dữ liệu trả về của service
/// </summary>
public class ServiceResult
{
    /// <summary>
    /// Thành công hay Thất bại
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Mã lỗi trả về (nếu có)
    /// </summary>
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Dữ liệu trả về kèm (nếu có)
    /// </summary>
    public string? Data { get; set; }

    /// <summary>
    /// Message trả về kèm (nếu có)
    /// </summary>
    public string? Message { get; set; }
}

/// <summary>
/// Thông tin nhân viên
/// </summary>
public class Employee
{
    /// <summary>
    /// Khóa chính
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Mã nhân viên
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Tên nhân viên
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Mã số thuế
    /// </summary>
    public string TaxCode { get; set; }
}

/// <summary>
/// Base service
/// </summary>
public class BaseService<T>
{
    /// <summary>
    /// Thêm mới 1 đối tượng
    /// </summary>
    /// <param name="dbConnection">Thông tin kết nối đến database</param>
    /// <param name="entity">Đối tượng muốn thêm mới</param>
    /// <returns>
    /// Nếu thêm mới thành công thì đối tượng ServiceResult trả về có IsSuccess = true. 
    /// Nếu thêm mới thất bại thì đối tượng ServiceResult trả về có IsSuccess = false. 
    /// </returns>
    public async Task<ServiceResult> InsertAsync(
        IDbConnection dbConnection,
        T entity)
    {

        // Các class con có thể override hàm này 
        await BeforeInsertAsync(dbConnection, ent﻿ity);

        // Do something else

        await InsertToDatabaseAsync(dbConnection, ent﻿ity);

        // Do something else

        return new ServiceResult { IsSuccess = true };
    }

    /// <summary>
    /// Hàm xử lý dữ liệu trước khi thêm mới dữ liệu. Các class con có thể override hàm này 
    /// </summary>
    /// <param name="dbConnection">Thông tin kết nối đến database</param>
    /// <param name="entity">Đối tượng muốn thêm mới</param>
    public virtual async Task BeforeInsertAsync(
        IDbConnection db﻿Connection,
        T enti﻿ty)
    {
        // Do something
    }

    /// <summary>
    /// Hàm thêm mới dữ liệu vào database
    /// </summary>
    /// <param name="dbConnection">Thông tin kết nối đến database</param>
    /// <param name="entity">Đối tượng muốn thêm mới</param>
    public virtual async Task InsertToDatabaseAsync(
        IDbConnection db﻿Connection,
        T enti﻿ty)
    {
        // Do something
    }
}

/// <summary>
/// Service xử lý nghiệp vụ với đối tượng nhân viên
/// </summary>
public class EmployeeService : BaseService<Employee>
{
    /*
     * Override:
     * - Gắn chặt với tính KẾ THỪA
     * - Cùng tên hàm: BeforeInsertAsync
     * - CÙNG tham số đầu vào
     */
    public override async Task BeforeInsertAsync(
        IDbConnecti﻿on db﻿Connection,
        Employee employee)
    {
        // Do something
        ValidateTaxCode(employee.TaxCode);
        // Do something else
    }

    /// <summary>
    /// Hàm thêm mới dữ liệu vào database
    /// </summary>
    /// <param name="taxCode">Mã số thuế muốn validate</param>
    public void ValidateTaxCode(string taxCode)
    {
        // Do something
    }
}

