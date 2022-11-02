import React, { Component } from "react";
import axios from "axios";
import swal from "sweetalert";

export default class quatationRequests extends Component {
  constructor(props) {
    super(props);
    this.state = {
      description: "",
      numberOfItem: "",//qty
      totalPrice: "",
      productId: "",
    };
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

    const { description,  } =
      this.state;

    const data = {
      
      description: description,
    };

    console.log(data);

    // Validation

    if (
      // PassBook.length === 0 ||
      description.length === 0
      
    ) {
      swal(" Fields Cannot empty !", "Please enter all data !", "error");
    }else if(description.length < 4 ){
      swal("Invalid description !", "Length shuld be greater than 4 !", "error");
    }else {
      axios.post("https://localhost:7088/api/Order/savePurchaseRequests", data).then((res) => {
        if (res.data.success) {
          this.setState({
            description: "",
          });
        }
      });
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
                      <select class="form-control">
                        <option>Default select</option>
                        <option>Default select</option>
                        <option>Default select</option>
                        <option>Default select</option>
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
                        class="form-control"
                        name="expirdate"
                        placeholder="Date"
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
                      <select class="form-control">
                        <option>Default select</option>
                        <option>Default select</option>
                        <option>Default select</option>
                        <option>Default select</option>
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
