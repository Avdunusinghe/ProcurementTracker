import React, { Component } from "react";
import masterDataService from "../../services/masterData/master.data.service";
import axios from "axios";
import orderService from "../../services/order/order.service";

export default class Approve extends Component {
  constructor(props) {
    super(props);
    console.log(this.props.match.params.id);

    this.state = {
      products: [],
      purchaseRequest: {
        id: 0,
        purchaseRequestStatus: 0,
        requiredDeliveryDate: "",
        description: null,
        supplierId: 0,
        supplierName: "",
        totalPrice: 0,
        statusChangedByName: "",
        createdDate: "",
        purchaseRequestProductItems: [
          {
            id: 0,
            productId: 0,
            productName: "",
            numberOfItem: 0,
            purchaseRequestId: 0,
          },
        ],
      },
      productName: "",
      numberOfItem: 0,
      productId: 0,
      totalPrice: 0,
    };
  }

  componentDidMount() {
    this.getProduts();
    const id = this.props.match.params.id;

    this.getPurchesById(id);
  }

  getProduts() {
    masterDataService.getProductMasterData().then((response) => {
      this.setState({
        products: response.data,
      });
      console.log(response.data);
      this.getSupplier();
    });
  }

  handleInputChange = (e) => {
    const { name, value } = e.target;

    this.setState({
      ...this.state,
      [name]: value,
    });
  };

  getPurchesById = (id) => {
    orderService.getPurchesById(id).then((response) => {
      this.setState({
        purchaseRequest: response.data,
      });
    });

    console.log(
      this.state.purchaseRequest.purchaseRequestProductItems[0].productId
    );
  };

  onSubmit = (e) => {
    // e.preventDefault();
    const id = this.props.match.params.id;

    const { purchaseRequest, productId, numberOfItem, totalPrice } = this.state;

    const purchaseRequestModel = {
      id: purchaseRequest.id,
      productId: purchaseRequest.purchaseRequestProductItems[0].productId,
      purchaseRequestStatus: 1,
      requiredDeliveryDate: purchaseRequest.requiredDeliveryDate,
      description: purchaseRequest.description,
      supplierId: purchaseRequest.supplierId,
      totalPrice: totalPrice,
      statusChangedBy: "string",
      purchaseRequestProductItems: [
        {
          id: 0,
          productId: productId,
          productName: "string",
          numberOfItem: numberOfItem,
          purchaseRequestId: purchaseRequest.id,
        },
      ],
    };

    console.log(purchaseRequestModel);
    orderService.saveRequest(purchaseRequestModel).then((response) => {
      console.log(response.data);
      localStorage.setItem("purchaseRequest", JSON.stringify(response.data));
    });
  };

  render() {
    return (
      <div>
        <div>
          <div style={{ marginLeft: "550px" }}>
            <h3 style={{ marginLeft: "40px", marginTop: "20px" }}>
              <b>Recieved Quotation</b>
            </h3>
          </div>
          <form onSubmit={this.onSubmit} style={{ backgroundColor: "#bbbec4" }}>
            <div class="row">
              <div class="col">
                {/* <div class="dropdown"  style={{width:'280px', marginTop:'60px', marginLeft:'230px'  }} >
  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Material
  </button>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <a class="dropdown-item" href="#"> </a>
    <a class="dropdown-item" href="#"> </a>
    <a class="dropdown-item" href="#"> </a>
  </div>
</div> */}
                <div
                  style={{
                    width: "560px",
                    marginTop: "40px",
                    marginLeft: "80px",
                  }}
                >
                  <div class="col">
                    <label for="exampleFormControlSelect1">
                      <b>Material</b>
                    </label>
                    <select
                      class="form-select"
                      name="productId"
                      value={
                        this.state.purchaseRequest
                          .purchaseRequestProductItems[0].productId
                      }
                      onChange={this.handleInputChange}
                    >
                      <option selected>Please Select</option>
                      {this.state.products.map((product, index) => (
                        <option key={product.id} value={product.id}>
                          {product.name}
                        </option>
                      ))}
                    </select>
                  </div>
                </div>
              </div>

              <div class="col">
                <input
                  style={{
                    width: "220px",
                    marginTop: "60px",
                    marginLeft: "75px",
                  }}
                  type="text"
                  class="form-control"
                  placeholder="Qty"
                  name="numberOfItem"
                  value={
                    this.state.purchaseRequest.purchaseRequestProductItems[0]
                      .numberOfItem
                  }
                  onChange={this.handleInputChange}
                />
              </div>

              <div class="col">
                <input
                  style={{
                    width: "220px",
                    marginTop: "60px",
                    marginLeft: "0px",
                  }}
                  type="text"
                  class="form-control"
                  placeholder=" Estimate Cost "
                  value={this.state.purchaseRequest.totalPrice}
                  onChange={this.handleInputChange}
                />
              </div>
            </div>
            {/* 
   <input   style={{width:'220px', marginTop:'60px', marginLeft:'615px'  }} 
   type="text"
   class="form-control" 
   placeholder=" Estimate Cost"/> */}

            <br></br>
            <br></br>
            <button
              style={{ marginLeft: "670px" }}
              class="btn btn-primary"
              type="submit"
            >
              Update
            </button>
            <br></br>
            <br></br>
          </form>
        </div>
        <div style={{ marginLeft: "550px", marginTop: "20px" }}>
          <h3 style={{ marginLeft: "40px", marginTop: "10px" }}>
            <b>Approve Quotation</b>
          </h3>
        </div>
        <form
          style={{
            width: "520px",
            height: "70px",
            marginLeft: "500px",
            marginTop: "100px",
          }}
        >
          <div class="form-group">
            {/* <label for="exampleFormControlInput1">Email address</label>
    <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com"/> */}
          </div>

          <div class="form-group">
            <label for="exampleFormControlSelect1">
              <b>Select Supplier To Approve</b>
            </label>
            <select class="form-control">
              <option>Default select</option>
              <option>Default select</option>
              <option>Default select</option>
              <option>Default select</option>
            </select>
          </div>

          <div class="form-group">
            <label for="exampleFormControlSelect2">
              <b>Site Address</b>
            </label>
            <textarea
              class="form-control"
              id="exampleFormControlTextarea1"
              rows="3"
            ></textarea>
          </div>

          <div class="form-group">
            <label for="exampleFormControlTextarea1">
              <b>Remark</b>
            </label>
            <textarea
              class="form-control"
              id="exampleFormControlTextarea1"
              rows="3"
            ></textarea>
          </div>

          <button class="btn btn-primary" type="submit">
            Submit form
          </button>
        </form>
      </div>
    );
  }
}
