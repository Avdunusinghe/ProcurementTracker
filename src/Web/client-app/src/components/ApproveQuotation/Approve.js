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
            productId: 0,
            productName: "",
            numberOfItem: 0,
            purchaseRequestId: 0,
          },
        ],
      },
      productName: "",
      numberOfItem: "",
      productId: 0,
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
      console.log(response.data);
      this.setState({
        purchaseRequest: response.data,
      });
    });

    console.log(
      this.state.purchaseRequest.purchaseRequestProductItems[0].productId
    );
  };

  onSubmit = (e) => {
    e.preventDefault();
    const id = this.props.match.params.id;

    const { productId, productName, numberOfItem } = this.state;

    const data = {
      productId: 0,
      productName: productName,
      numberOfItem: numberOfItem,
    };
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
          <form style={{ backgroundColor: "#bbbec4" }}>
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
        <br/>
        <br/>
        <div className="text-center">
        <a
                        className="btn btn-primary"
                        href={'/email'}
                      >
                        <i className="fas fa-email"> Send Approval</i>
                      </a></div>
      </div>
    );
  }
}
