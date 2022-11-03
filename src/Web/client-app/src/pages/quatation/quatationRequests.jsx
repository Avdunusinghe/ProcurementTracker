import React, { Component } from "react";
import axios from "axios";
import swal from "sweetalert";
import masterDataService from "../../services/masterData/master.data.service";
import orderService from "../../services/order/order.service";

export default class quatationRequests extends Component {
  constructor(props) {
    super(props);
    this.state = {
      suppliers: [],
      products: [],
      description: "",
      numberOfItem: 0, //qty
      totalPrice: 0,
      productId: 0,
      supplierId: 0,
    };
  }
  componentDidMount() {
    this.getProduts();
  }

  getProduts() {
    masterDataService.getProductMasterData().then((response) => {
      this.setState({
        products: response.data,
      });

      this.getSupplier();
    });
  }

  getSupplier() {
    masterDataService.getSupplierMasterData().then((response) => {
      this.setState({
        suppliers: response.data,
      });
    });
  }

  handleInputChange = (e) => {
    const { name, value } = e.target;

    this.setState({
      ...this.state,
      [name]: value,
    });
  };

  onSubmit = (e) => {
    e.preventDefault();

    const {
      description,
      numberOfItem,
      productId,
      supplierId,
      totalPrice,
      requiredDeliveryDate,
    } = this.state;

    const data = {
      productId: 0,
      purchaseRequestStatus: 1,
      requiredDeliveryDate: requiredDeliveryDate,
      description: description,
      supplierId: supplierId,
      totalPrice: totalPrice,
      statusChangedBy: "string",
      purchaseRequestProductItems: [
        {
          productId: 1,
          productName: "string",
          numberOfItem: numberOfItem,
          purchaseRequestId: 0,
        },
      ],
    };

    console.log(data);

    // Validation

    if (
      numberOfItem.length === 0 ||
      description.length === 0 ||
      productId.length === 0 ||
      totalPrice.length === 0
    ) {
      swal(" Fields Cannot empty !", "Please enter all data !", "error");
    } else if (description.length < 4) {
      swal(
        "Invalid description !",
        "Length shuld be greater than 4 !",
        "error"
      );
    } else {
      orderService.saveRequest(data).then((response) => {
        console.log(response.data);
      });
      /* axios
        .post("https://localhost:7088/api/Order/savePurchaseRequests", data)
        .then((res) => {
          console.log(res.data);
          if (res.data.isSuccess) {
          }
        }); */
      swal({
        text: "Data Successfully Added",
        icon: "success",
        button: "Okay!",
      }).then((value) => {
        window.location = "/"; //
      });
    }
  };

  render() {
    return (
      <div>
        <div>
          <div>
            <br />
            <h3 className="p-text-center">
              <b>Quotation Requests</b>
            </h3>
            <br />
          </div>
          <div style={{ marginLeft: "100px", marginRight: "100px" }}>
            <div>
              <form style={{ backgroundColor: "#e0f8ff" }}>
                <div class="row">
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
                        value={this.state.productId}
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
                  <div
                    style={{
                      width: "360px",
                      marginTop: "40px",
                      marginLeft: "20px",
                    }}
                  >
                    <div class="col">
                      <label for="exampleFormControlSelect1">
                        <b>Qty</b>
                      </label>
                      <input
                        type="text"
                        class="form-control"
                        placeholder="Qty"
                        name="numberOfItem"
                        value={this.state.numberOfItem}
                        onChange={this.handleInputChange}
                      />
                    </div>
                  </div>
                </div>

                <div class="row">
                  <div
                    style={{
                      width: "260px",
                      marginTop: "40px",
                      marginLeft: "80px",
                    }}
                  >
                    <div class="col">
                      <label for="exampleFormControlSelect1">
                        <b>Estimated Cost</b>
                      </label>
                      <input
                        type="text"
                        class="form-control"
                        placeholder="Estimated Cost"
                        name="totalPrice"
                        value={this.state.totalPrice}
                        onChange={this.handleInputChange}
                      />
                    </div>
                  </div>
                  <div
                    style={{
                      width: "280px",
                      marginTop: "40px",
                      marginLeft: "20px",
                    }}
                  >
                    <div class="col">
                      <label for="exampleFormControlSelect1">
                        <b>Required Delivery Date</b>
                      </label>
                      <input
                        type="date"
                        className="form-control"
                        placeholder="Date"
                        name="requiredDeliveryDate"
                        value={this.state.requiredDeliveryDate}
                        onChange={this.handleInputChange}
                      />
                    </div>
                  </div>
                  <div
                    style={{
                      width: "360px",
                      marginTop: "40px",
                      marginLeft: "20px",
                    }}
                  >
                    <div class="col">
                      <label for="exampleFormControlSelect1">
                        <b>Select Suppliers</b>
                      </label>
                      <select
                        class="form-select"
                        name="supplierId"
                        value={this.state.supplierId}
                        onChange={this.handleInputChange}
                      >
                        <option selected>Please Select</option>

                        {this.state.suppliers.map((suppliers) => (
                          <option key={suppliers.id} value={suppliers.id}>
                            {suppliers.name}
                          </option>
                        ))}
                      </select>
                    </div>
                  </div>
                </div>

                <div class="row">
                  <div
                    style={{
                      width: "940px",
                      marginTop: "40px",
                      marginLeft: "80px",
                      marginRight: "70px",
                    }}
                  >
                    <div class="col">
                      <label for="exampleFormControlSelect1">
                        <b>Description</b>
                      </label>
                      <textarea
                        class="form-control"
                        id="exampleFormControlTextarea1"
                        placeholder="Description"
                        rows="3"
                        name="description"
                        value={this.state.description}
                        onChange={this.handleInputChange}
                      ></textarea>
                    </div>
                  </div>
                </div>

                <br />
                <div className="p-text-center">
                  <button
                    onClick={this.onSubmit}
                    class="btn btn-primary"
                    type="submit"
                    style={{
                      width: "150px",
                    }}
                  >
                    Send
                  </button>
                </div>
                <br />
                <br />
              </form>
            </div>
            <br />
            <br />
          </div>
        </div>
      </div>
    );
  }
}
