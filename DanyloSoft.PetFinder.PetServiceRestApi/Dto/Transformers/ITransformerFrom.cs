namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto.Transformers
{
  public interface ITransformerFrom<FT>
  {
    TT Post<TT>(FT postType);
    TT Put<TT>(FT putType);
    TT GetById<TT>(FT getType);
  }
}