namespace Pretech.Software.RConfig.Core.Response
{
    public class DBResponseBase<T>
    {
        #region Properties
        public T Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        #endregion

        #region Constructor
        public DBResponseBase()
        {

        }
        public DBResponseBase(T data)
        {
            //this.Data = data ?? throw new Exception("Generic data type is not null !");
            this.Data = data;
        }
        #endregion

        #region Action methods
        public DBResponseBase<T> Success(T data)
        {
            this.Data = data;
            this.IsSuccess = true;
            this.Message = null;
            return this;
        }
        public DBResponseBase<T> Success()
        {
            this.IsSuccess = true;
            this.Message = null;
            return this;
        }
        public DBResponseBase<T> Success(T data, string message)
        {
            this.IsSuccess = true;
            this.Data = data;
            this.Message = message;
            return this;
        }

        public DBResponseBase<T> Maintance()
        {
            this.IsSuccess = false;
            this.Data = default(T);
            this.Message = null;
            return this;
        }

        public DBResponseBase<T> Error(string message)
        {
            this.Data = default(T);
            this.IsSuccess = false;
            this.Message = message;
            return this;
        }
        public DBResponseBase<T> Error(Exception ex)
        {
            this.Data = default(T);
            this.Message = $"Exception;{ex.Message}- Stack : {ex.StackTrace}";
            this.IsSuccess = false;
            return this;
        }
        #endregion
    }
}
