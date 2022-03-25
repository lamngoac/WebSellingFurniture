import Enum from '@/enum/enum';
import moment from 'moment';

const keyOrderStorage = "Web-Order";
class CommonFunc {
    convertImgSaveDB(img) {
        img = img.toString();
        if (img) {
            let res = img.split('\\');
            if (res) {
                img = res.at(res.length - 1);
                return img;
            }
        }
        return "";
    }
    async getBase64FromImage(file) {
        return new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = () => resolve(reader.result);
            reader.onerror = error => reject(error);
        })
    }
    /**
     * Thêm order vào giỏ hàng
     */
    addCart(userName, order) {
        let store = localStorage.getItem(keyOrderStorage)
        let orderStorage = !store ? {} : JSON.parse(store);

        if (!orderStorage[`${userName}`]) {
            orderStorage[`${userName}`] = {};
            orderStorage[`${userName}`].orders = [];
            orderStorage[`${userName}`].orders.push(order);
            orderStorage[`${userName}`] = {
                orders: orderStorage[`${userName}`].orders
            }
        }
        else {
            let exist = order && orderStorage[`${userName}`].orders.filter(x => x.product.productId == order.product.productId) && orderStorage[`${userName}`].orders.filter(x => x.product.productId == order.product.productId).length > 0;
            if (exist) {
                let index = orderStorage[`${userName}`].orders.findIndex((obj => obj.product.productId == order.product.productId));
                orderStorage[`${userName}`].orders[index].amount += order.amount;
            }
            else {
                orderStorage[`${userName}`].orders.push(order);
                orderStorage[`${userName}`] = {
                    orders: orderStorage[`${userName}`].orders
                }
            }
        }
        localStorage.setItem(`${keyOrderStorage}`, JSON.stringify(orderStorage));
    }

    /**
     * Lấy thông tin giỏ hàng của user
     */
    getCartByUser(userName) {
        let orderUserName = {};
        // Lấy dữ liệu trên storgare
        let store = localStorage.getItem(keyOrderStorage);
        if (!store) return orderUserName;

        // convert dữ liệu
        let orderStorage = JSON.parse(store);
        if (!orderStorage) return orderUserName;

        if (orderStorage[userName]) {
            orderUserName = {
                orders: orderStorage[userName].orders
            };
        }
        return orderUserName;
    }
    /**
     * reset dữ liệu trên storage của user
     */
    updateCartByUser(userName) {
        let store = localStorage.getItem(keyOrderStorage)
        let orderStorage = !store ? {} : JSON.parse(store);
        if (!orderStorage[`${userName}`]) {
            orderStorage[`${userName}`] = {};
        }
        if (orderStorage[`${userName}`].orders) {
            orderStorage[`${userName}`].orders = [...orderStorage[`${userName}`].orders.filter(x => !x.selected)];
            localStorage.setItem(`${keyOrderStorage}`, JSON.stringify(orderStorage));
            return;
        }
        orderStorage[`${userName}`].orders = [];
        localStorage.setItem(`${keyOrderStorage}`, JSON.stringify(orderStorage));
    }

    resetCartByUser(userName) {
        let store = localStorage.getItem(keyOrderStorage)
        let orderStorage = !store ? {} : JSON.parse(store);
        orderStorage[`${userName}`] = {};
        orderStorage[`${userName}`].orders = [];
        localStorage.setItem(`${keyOrderStorage}`, JSON.stringify(orderStorage));
    }

    /**
     * Lấy tên tài khoản
     */
    getUserName() {
        let name = localStorage.getItem("userName");
        if (!name) {
            name = "";
        }
        return name;
    }

    getTotalMoneyOrderByUser(userName) {
        const me = this;
        if (userName) {
            let orders = [...me.getCartByUser(userName)];
            if (orders && orders.length > 1) {
                return orders.reduce((a, { amount, product }) => a + amount * product.productSalePrice, 0);
            }
            if (orders && orders.length == 1) {
                return orders[0].amount * orders[0].product.productSalePrice;
            }
            return null;
        }
        return null;
    }
    getAmountTotalOrderByUser(userName) {
        if (userName) {
            const me = this;
            let orders = [...me.getCartByUser(userName)];
            if (orders && orders.length > 1) {
                return orders.reduce((a, { amount }) => a + amount, 0);
            }
            if (orders && orders.length == 1) {
                return orders[0].amount;
            }
        }
        return null;
    }

    /**
     * format Data
     * @param {*} format 
     * @param {*} data 
     */
    formatData(format, data) {
        let res = null;
        switch (format) {
            case Enum.Format.Number:
                break;
            case Enum.Format.Money:
                res = new Intl.NumberFormat().format(data).replaceAll(",", ".");
                break;
            case Enum.Format.Date:
                res = moment(data).format("DD/MM/YYYY");
                break;
            case Enum.Format.Color:
                switch (data) {
                    case Enum.Color.Green:
                        res = "Màu xanh";
                        break;
                    case Enum.Color.Brown:
                        res = "Màu nâu";
                        break;
                    case Enum.Color.Yellow:
                        res = "Màu vàng";
                        break;
                    case Enum.Color.DarkBrown:
                        res = "Màu nâu sẫm";
                        break;
                    default:
                        res = data;
                        break;
                }
                break;
            case Enum.Format.PaymentMethods:
                switch(data){
                    case Enum.PaymentMethods.Cash:
                        res = "Tiền mặt";
                        break;
                    case Enum.PaymentMethods.Transfer:
                        res = "Chuyển khoản";
                        break;
                }
                break;
            case Enum.Format.OrderStatus:
            switch(data){
                case Enum.OrderStatus.WaitConfirm:
                    res = "Chờ xác nhận";
                    break;
                case Enum.OrderStatus.WaitProduct:
                    res = "Đang lấy hàng";
                    break;
                case Enum.OrderStatus.Delivering:
                    res = "Đang giao hàng";
                    break;
                case Enum.OrderStatus.Fail:
                    res = "Giao hàng thất bại";
                    break;
                case Enum.OrderStatus.Success:
                    res = "Giao hàng thành công";
                break;
            }
        }
        return res;
    }
}

export default new CommonFunc();