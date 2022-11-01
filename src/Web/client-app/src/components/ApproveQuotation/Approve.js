import React, { Component } from 'react';
import axios from 'axios';

export default class Approve extends Component {

constructor(props) {
    super(props);
    this.state = {
    id:'',
      productName: "",
      numberOfItem: "",
      
    }
  }

 handleInputChange = (e) => {
    const { name, value } = e.target;

    this.setState({
      ...this.state,
      [name]: value
    })

  }

  onSubmit = (e) => {

    e.preventDefault();
    const id = this.props.match.params.id;

    const {  productName, numberOfItem} = this.state;

    const data = {
      productName: productName,
      numberOfItem: numberOfItem,
      

    }

    console.log(data)
    
    axios.put(`https://localhost:7088/api/Order/savePurchaseRequest`, {'purchaseRequest.Id':0}).then((res) => {
      if (res.data) {

        alert("Update Successful", "Update is recorder", "success");
        this.setState(
          {
            id:"",
            productName: "",
        numberOfItem: "",
          

          }
        )
      }
    })
  
  }

  componentDidMount() {

    const id = this.props.match.params.id;


    axios.get("https://localhost:7088/api/Order/getPurchaseRequests", {"purchaseRequestStatus": 1}).then((res) => {

      if (res.data.success) {
        this.setState({

        Id:res.data.post.Id,
          productName: res.data.post.productName,
          numberOfItem: res.data.post.numberOfItem,
         

        });

        console.log(this.state.post);
      }
    })

  }

  render() {
    return (
      <div>
<div>
    <div style={{marginLeft: '550px'}}>
<h3 style={{marginLeft:'40px', marginTop:"20px", }}><b>Recieved Quotation</b></h3>
</div>
    <form>
  <div class="row">
    <div class="col">
      <input   style={{width:'220px', marginTop:'60px', marginLeft:'200px'  }} type="text" class="form-control" name=" productName" value={this.state. productName}
													onChange={this.handleInputChange}
placeholder="Material"/>
    </div>
    <div class="col">
      <input   style={{width:'220px', marginTop:'60px', marginLeft:'75px'  }} type="text" class="form-control" placeholder="Qty"  name="numberOfItem" value={this.state. numberOfItem}
													onChange={this.handleInputChange}/>
    </div>
    <div class="col">
      <input   style={{width:'220px', marginTop:'60px', marginLeft:'0px'  }} type="text" class="form-control" placeholder="Delievery State "/>
    </div>
  </div>
   <input   style={{width:'220px', marginTop:'60px', marginLeft:'600px'  }} type="text" class="form-control" placeholder=" Estimate Cost"/>
</form>
</div>
<div style={{marginLeft: '550px', marginTop:"20px"}}>
<h3 style={{marginLeft:'40px', marginTop:"10px"}}><b>Approve Quotation</b></h3>
</div>
<form    style={{width:'520px', height:'70px', marginLeft:'500px', marginTop:'100px'}}>
  <div class="form-group">
    
    {/* <label for="exampleFormControlInput1">Email address</label>
    <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com"/> */}
  </div>
  
  <div class="form-group">
    <label for="exampleFormControlSelect1"><b>Select Supplier To Approve</b></label>
   <select class="form-control">
  <option>Default select</option>
  <option>Default select</option>
  <option>Default select</option>
  <option>Default select</option>
</select>
  </div>
  <div class="form-group">
    <label for="exampleFormControlSelect2"><b>Site Address</b></label>
        <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>

  </div>
  <div class="form-group">
    <label for="exampleFormControlTextarea1"><b>Remark</b></label>
    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
   
  </div>
    <button class="btn btn-primary" type="submit">Submit form</button>
</form>
 
      </div>
    )
  }
}
