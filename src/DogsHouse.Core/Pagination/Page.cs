namespace DogsHouse.Core.Pagination;

public class Page
{
    private int pageNumber;
    private int pageSize;

    public Page()
    {
        PageNumber = Constants.DefaultPageNumber;
        PageSize = Constants.DefaultPageSize;
    }

    public int PageNumber
    {
        get { return pageNumber; }
        set
        {
            if (value <= 0)
            {
                pageNumber = Constants.DefaultPageNumber;
            }
            else
            {
                pageNumber = value;
            }
        }
    }

    public int PageSize
    {
        get { return pageSize; }
        set
        {
            if (value > Constants.MaxPageSize || value < Constants.MinPageSize)
            {
                pageSize = Constants.DefaultPageSize;
            }
            else
            {
                pageSize = value;
            }
        }
    }
}