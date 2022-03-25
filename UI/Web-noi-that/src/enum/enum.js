export default{
    Role : {
        Admin : 1,
        User : 2
    },

    PaymentMethods :{
        /// <summary>
        /// Chuyển khoản
        /// </summary>
        Transfer : 0,
        /// <summary>
        /// Tiền mặt, thanh toán khi nhận hàng
        /// </summary>
        Cash : 1,
    },

    Color : {
        Green : 1,
        Brown : 2,
        Yellow : 3,
        DarkBrown : 4
    },

    Format : {
        Number : 1,
        Money : 2,
        Date : 3,
        Color : 4,
        PaymentMethods : 5,
        OrderStatus: 6,
    },

    SortStatus:{
        None : 0,
        Desc : 1,
        Asc  : 2
    },

    OrderStatus : {
        // chờ xác nhận
        WaitConfirm : 5,
        // chờ lấy hàng
        WaitProduct : 1,
        // Đang giao
        Delivering : 2,
        // Đã giao
        Fail : 3,
        Success : 4,
    }
}