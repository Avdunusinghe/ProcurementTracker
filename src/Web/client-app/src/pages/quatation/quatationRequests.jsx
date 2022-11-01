import React, { Component } from "react";

export default class quatationRequests extends Component {
  render() {
    return (
      <div>
        <div>
          <div>
            <br />
            <h3 className="p-text-center">
              <b>Quatation Requests</b>
            </h3>
            <br />
          </div>
          <div style={{ marginLeft: "100px", marginRight: "100px" }}>
            <div>
            <form style={{ backgroundColor: "#e0f8ff" }}>
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
                    width: "260px",
                    marginTop: "40px",
                    marginLeft: "80px",
                  }}
                >
                  <div class="col">
                    <label for="exampleFormControlSelect1">
                      <b>Qty</b>
                    </label>
                    <input type="text" class="form-control" placeholder="Qty" />
                  </div>
                </div>
                <div
                  style={{
                    width: "260px",
                    marginTop: "40px",
                    marginLeft: "80px",
                  }}
                >
                  <div class="col">
                    <label for="exampleFormControlSelect1">
                      <b>Delivery Status</b>
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
                    />
                  </div>
                </div>
                <div
                  style={{
                    width: "260px",
                    marginTop: "40px",
                    marginLeft: "80px",
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
                    />
                  </div>
                </div>
                <div
                  style={{
                    width: "260px",
                    marginTop: "40px",
                    marginLeft: "80px",
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
                    ></textarea>
                  </div>
                </div>
              </div>

              <br />
              <div className="p-text-center">
                <button
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
