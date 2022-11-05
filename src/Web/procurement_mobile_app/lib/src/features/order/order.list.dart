import 'dart:async';
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class OrderList extends StatefulWidget {
  const OrderList({Key? key}) : super(key: key);

  @override
  State<OrderList> createState() => _OrderListState();
}

class _OrderListState extends State<OrderList> {
  List orders = [];
  bool isLoading = false;
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    this.fetchOrders();
  }

  fetchOrders() async {
    setState(() {
      isLoading = true;
    });
    var url = "https://localhost:7088/api/Order/getOrders";
    var response = await http.post(Uri.parse(url));
    if (response.statusCode == 200) {
      var items = json.decode(response.body)['results'];
      setState(() {
        orders = items;
        isLoading = false;
      });
    } else {
      setState(() {
        orders = [];
        isLoading = false;
      });
    }
  }
// Future<void> fetchOrders() async {
//     final storage = new FlutterSecureStorage();
//     final String? authToken = await storage.read(key: 'token');

//     final response = await http
//         .get(Uri.parse('http://localhost:4000/api/question'), headers: {
//       'Content-Type': 'application/json; charset=UTF-8',
//       'authorization': "Bearer $authToken",
//     });

//     final responseJson = jsonDecode(response.body);

//     for (Map<String, dynamic> item in responseJson) {
//       this.questionList.add(BasicQuestionModel.fromJson(item));
//     }

//     setState(() {
//       this.questionList = this.questionList;
//     });

//     for (var item in this.questionList) {
//       print(item.id);
//     }
//   }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Order List"),
      ),
      body: getBody(),
    );
  }

  Widget getBody() {
    if (orders.contains(null) || orders.length < 0 || isLoading) {
      return Center (child: CircularProgressIndicator(valueColor: new AlwaysStoppedAnimation<Color>(Colors.blue),));
    }
    return ListView.builder(
        itemCount: orders.length,
        itemBuilder: (context, index) {
          return getCard(orders[index]);
        });
  }

  Widget getCard(item) {
    var material = item['ID']['name'] + " " + item['name']['first'];
    var date = item['date'];
    return Card(
      child: Padding(
          padding: EdgeInsets.all(10.0),
          child: ListTile(
              title: Row(
            children: <Widget>[
              Container(
                width: 60,
                height: 80,
                decoration: BoxDecoration(
                    color: Colors.blue,
                    borderRadius: BorderRadius.circular(60 / 2),
                    image: DecorationImage(
                        fit: BoxFit.cover,
                        image: NetworkImage(
                            "https://freedesignfile.com/upload/2017/03/City-building-construction-template-vectors-19.jpg"))),
              ),
              SizedBox(
                width: 20,
              ),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  Text(
                    material.toString(),
                    style: TextStyle(fontSize: 17),
                  ),
                  SizedBox(
                    height: 10,
                  ),
                  Text(
                    date.toString(),
                    style: TextStyle(
                      color: Colors.grey,
                    ),
                  ),
                ],
              )
            ],
          ))),
    );
  }
}
