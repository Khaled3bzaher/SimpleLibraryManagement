using SimpleLibraryManagement.Application.DTOs.Borrower;
using SimpleLibraryManagement.Application.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Application.Interfaces
{
    public interface IBorrowerService
    {
        Task<List<BorrowerDto>> GetBorrowersAsync();

        Task<ApiResponse<BorrowerDto>> GetBorrowerAsync(int borrowerId);
        Task<ApiResponse<bool>> EditBorrowerAsync(int borrowerId, BorrowerDto borrowerModel);
        Task<ApiResponse<bool>> DeleteBorrowerAsync(int borrowerId);
        Task<ApiResponse<bool>> CreateBorrowerAsync(BorrowerDto borrowerModel);


    }
}
