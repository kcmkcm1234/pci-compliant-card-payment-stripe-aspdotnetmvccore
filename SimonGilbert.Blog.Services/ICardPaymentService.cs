using SimonGilbert.Blog.ViewModels;

namespace SimonGilbert.Blog.Services
{
    public interface ICardPaymentService
    {
        CardPaymentReceiptViewModel Create(CardPaymentViewModel viewModel);
    }
}
