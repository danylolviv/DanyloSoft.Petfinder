namespace DanyloSoft.PetFinder.PetServiceRestApi.Dto.Transformers
{
  public interface ITransformerTo<FT>
  {
    TT Post<TT>(FT fromType);
    TT Put<TT>(FT fromType);
    TT GetById<TT>(FT fromType);
  }
}