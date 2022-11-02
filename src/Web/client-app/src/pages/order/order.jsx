import "primeicons/primeicons.css";
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.css";
import "primeflex/primeflex.css";
import "../../index.css";

import React, { useState, useEffect, useRef } from "react";
import { classNames } from "primereact/utils";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Dropdown } from "primereact/dropdown";
import { Toast } from "primereact/toast";
import { Button } from "primereact/button";
import { FileUpload } from "primereact/fileupload";
import { Rating } from "primereact/rating";
import { Toolbar } from "primereact/toolbar";
import { InputTextarea } from "primereact/inputtextarea";
import { RadioButton } from "primereact/radiobutton";
import { InputNumber } from "primereact/inputnumber";
import { Dialog } from "primereact/dialog";
import { InputText } from "primereact/inputtext";
import moment from "moment/moment";
import "./order.css";
import orderService from "../../services/order/order.service";
import masterDataService from "../../services/masterData/master.data.service";

export const Order = () => {
  let orderModel = {
    id: 0,
    referenceId: "",
    totalPrice: null,
    supplierName: "",
    supplierId: 0,
    shippingDate: null,
    orderByName: "",
    orderStatusResult: "",
    totalPrice: 0,
    lastModifiedByName: "",
    orderItems: [
      {
        id: 0,
        numberOfItems: 0,
        productId: 0,
        productName: "",
        itemPrice: 0,
        orderId: 0,
        totalPriceProduct: 0,
      },
    ],
  };

  const [products, setProducts] = useState(null);
  const [orderDialog, setOrderDialog] = useState(false);
  const [deleteProductDialog, setDeleteProductDialog] = useState(false);
  const [deleteProductsDialog, setDeleteProductsDialog] = useState(false);
  const [selectedProducts, setSelectedProducts] = useState(null);
  const [submitted, setSubmitted] = useState(false);
  const [globalFilter, setGlobalFilter] = useState(null);
  const toast = useRef(null);
  const dt = useRef(null);

  const [supliers, setSupliers] = useState(null);
  const [product, setProduct] = useState(null);
  const [order, setOrder] = useState(orderModel);
  const [orderStatus, setOrderStatus] = useState(null);
  const [orders, setOrders] = useState(null);
  const [orderStatusFilter, setOrderStatusFilter] = useState(0);
  const [supplierFilter, setSupplierFilter] = useState(0);
  useEffect(() => {
    getAllOrders();
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  const formatCurrency = (value) => {
    return value.toLocaleString("en-US", {
      style: "currency",
      currency: "USD",
    });
  };

  const getAllOrders = (supplier, orderStatus) => {
    const filter = {
      supplier: supplier,
      orderStatus: orderStatus,
    };

    orderService.getAllOrders(filter).then((response) => {
      setOrders(response.data);
      getOrderStatusMasterData();
    });
  };

  const getOrderStatusMasterData = () => {
    masterDataService.getOrderStatusMasterData().then((response) => {
      setOrderStatus(response.data);
      getSupplierMasterData();
    });
  };

  const getSupplierMasterData = () => {
    masterDataService.getSupplierMasterData().then((response) => {
      setSupliers(response.data);
      getProductMasterData();
    });
  };

  const getProductMasterData = () => {
    masterDataService.getProductMasterData().then((response) => {
      setProduct(response.data);
    });
  };

  const hideDialog = () => {
    setSubmitted(false);
    setOrderDialog(false);
  };

  const hideDeleteProductDialog = () => {
    setDeleteProductDialog(false);
  };

  const hideDeleteProductsDialog = () => {
    setDeleteProductsDialog(false);
  };

  const processOrder = () => {
    setSubmitted(true);

    let _order = { ...order };

    const orderDTO = {
      id: _order.id,
      totalPrice: _order.totalPrice,
      supplierId: _order.supplierId,
      isProceesed: true,
      shippingDate: _order.shippingDate,
      orderStatus: _order.orderStatus,
      orderItems: _order.orderItems,
    };
    console.log(orderDTO);
    orderService
      .saveOrder(orderDTO)
      .then((response) => {
        if (response.data.isSuccess) {
          toast.current.show({
            severity: "success",
            summary: "Successful",
            detail: response.data.message,
            life: 3000,
          });
          setOrderDialog(false);
          setOrder(orderModel);

          getAllOrders();
        } else {
          toast.current.show({
            severity: "error",
            summary: "Error",
            detail: response.data.message,
            life: 3000,
          });
        }
      })
      .finally(() => {
        setSubmitted(false);
      });
  };

  const editProduct = (product) => {};

  const confirmDeleteProduct = (product) => {};

  const deleteProduct = () => {};

  const findIndexById = (id) => {
    let index = -1;
    for (let i = 0; i < products.length; i++) {
      if (products[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  };

  const handleProcessOrder = (rowData) => {
    let model = rowData;
    model.id = rowData.id;
    console.log(model);
    setOrder({ ...model });
    setOrderDialog(true);
  };

  const importCSV = (e) => {};

  const exportCSV = () => {};

  const confirmDeleteSelected = () => {
    setDeleteProductsDialog(true);
  };

  const deleteSelectedProducts = () => {};

  const onCategoryChange = (e) => {};

  const onInputChange = (e, name) => {};

  const onInputNumberChange = (e, name) => {};

  const onOrderStatusChange = (event) => {
    setOrderStatusFilter(event.value);
    getAllOrders(supplierFilter.id, event.value.id);
  };

  const onSupplierChange = (event) => {
    setSupplierFilter(event.value);
    getAllOrders(event.value.id, orderStatusFilter.id);
  };

  const leftToolbarTemplate = () => {
    return (
      <React.Fragment>
        <div style={{ marginLeft: "1em" }}>
          <label>Order Status </label>
          <Dropdown
            value={orderStatusFilter}
            id="id"
            name="orderStatus"
            options={orderStatus}
            onChange={(event) => onOrderStatusChange(event)}
            optionLabel="name"
            placeholder="Select Order Status"
            style={{ marginLeft: "1em" }}
          />
        </div>

        <div style={{ marginLeft: "1em" }}>
          <label>Supplier Name </label>
          <Dropdown
            value={supplierFilter}
            options={supliers}
            onChange={(event) => onSupplierChange(event)}
            optionLabel="name"
            placeholder="Select Supplier"
            style={{ marginLeft: "1em" }}
          />
        </div>
      </React.Fragment>
    );
  };

  const rightToolbarTemplate = () => {};

  const priceBodyTemplate = (rowData) => {
    return formatCurrency(rowData.price);
  };

  const deliveryDataeBodyTemplate = (rowData) => {
    return moment(rowData.shippingDate).format("DD/MM/YYYY");
  };

  const actionBodyTemplate = (rowData) => {
    return (
      <React.Fragment>
        <Button
          label="Process Order"
          className="p-button p-button-warning mr-2"
          onClick={() => handleProcessOrder(rowData)}
        />
      </React.Fragment>
    );
  };

  const header = (
    <div className="table-header">
      <h5 className="mx-0 my-1">Manage Orders</h5>
    </div>
  );

  const orderDialogFooter = (
    <React.Fragment>
      <Button
        label="Cancel"
        icon="pi pi-times"
        className="p-button-text"
        onClick={hideDialog}
      />
      <Button
        label="Change Order Process"
        icon="pi pi-check"
        className="p-button-text"
        onClick={() => processOrder(order)}
      />
    </React.Fragment>
  );

  return (
    <div className="datatable-crud-demo card">
      <Toast ref={toast} />

      <div
        className="card"
        style={{
          marginTop: "5rem",
          marginLeft: "5rem",
          marginRight: "5rem",
        }}
      >
        <Toolbar
          className="mb-4"
          left={leftToolbarTemplate}
          right={rightToolbarTemplate}
        ></Toolbar>

        <DataTable
          ref={dt}
          dataKey="id"
          paginator
          value={orders}
          rows={10}
          header={header}
          responsiveLayout="scroll"
        >
          <Column
            field="supplierName"
            header="Supplier Name"
            sortable
            style={{ minWidth: "12rem" }}
          ></Column>
          <Column
            field="totalPrice"
            header="Total Price"
            sortable
            style={{ minWidth: "10rem" }}
          ></Column>
          <Column
            field="shippingDate"
            header="Shipping Date"
            body={deliveryDataeBodyTemplate}
          ></Column>
          <Column field="orderByName" header="Order By Name"></Column>
          <Column header="Action" body={actionBodyTemplate}></Column>
        </DataTable>
      </div>

      <Dialog
        visible={orderDialog}
        style={{ width: "800px" }}
        header="Order Details"
        modal
        className="p-fluid"
        footer={orderDialogFooter}
        onHide={hideDialog}
      >
        <div className="field">
          <label htmlFor="referenceId">ReferenceId </label>
          <InputText
            id="referenceId"
            value={order.referenceId}
            onChange={(event) => onInputChange(event, "referenceId")}
            disabled
          />
        </div>

        <div className="field">
          <label htmlFor="supplierName">Supplier Name </label>
          <InputText
            id="supplierName"
            value={order.supplierName}
            onChange={(event) => onInputChange(event, "supplierName")}
            disabled
          />
        </div>
        <div className="field">
          <label htmlFor="orderStatusResult">Order Status </label>
          <InputText
            id="orderStatusResult"
            value={order.orderStatusResult}
            onChange={(event) => onInputChange(event, "orderStatusResult")}
            disabled
          />
        </div>

        <div className="field">
          <label htmlFor="referenceId">Supllier </label>
          <Dropdown
            id="supplierId"
            name="supplierId"
            value={order.supplierId}
            options={supliers}
            optionLabel="name"
            placeholder="Select Supplier"
          />
        </div>
        <div className="field">
          <label htmlFor="referenceId">Order Status </label>
          <Dropdown
            id="orderStatus"
            name="orderStatus"
            value={order.orderStatus}
            options={orderStatus}
            optionLabel="name"
            placeholder="Order Status"
          />
        </div>
        <div className="field">
          <label htmlFor="referenceId">Order Items </label>
          <DataTable value={order.orderItems} responsiveLayout="scroll">
            <Column field="productName" header="Product Name"></Column>
            <Column field="numberOfItems" header="Item Count"></Column>
            <Column field="itemPrice" header="Item Price"></Column>
            <Column field="totalPriceProduct" header="Total Price"></Column>
          </DataTable>
        </div>
      </Dialog>
    </div>
  );
};
