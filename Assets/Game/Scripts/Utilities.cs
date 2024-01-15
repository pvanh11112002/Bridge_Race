using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utilities
{
    // Sorting a list
    // Nó sẽ trả về một danh sách mới sau khi sắp xếp (ngẫu nhiên) và giới hạn số lượng phần tử của danh sách đó theo giá trị của amount.
    // <T>: Đây là một tham số kiểu generics, cho phép phương thức hoạt động với các kiểu dữ liệu khác nhau mà không cần phải định nghĩa cụ thể.
    public static List<T> SortOrder<T>(List<T> list, int amount)
    {
        return list.OrderBy(d => System.Guid.NewGuid()).Take(amount).ToList();
    }
}
