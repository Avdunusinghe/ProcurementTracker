import 'package:flutter/material.dart';

class OrderSaveForm extends StatefulWidget {
  OrderSaveForm({Key? key, required this.saveOrder}) : super(key: key);
  final Function saveOrder;
  final userNameController = TextEditingController();
  final passwordController = TextEditingController();
  @override
  State<OrderSaveForm> createState() => _OrderSaveFormState();
}

class _OrderSaveFormState extends State<OrderSaveForm> {
  final _prodcutSizeList = ['Small', 'Medium', 'Large'];
  String? _slectedValue = '';
  @override
  Widget build(BuildContext context) {
    return Form(
      child: Container(
        padding: const EdgeInsets.only(left: 24, right: 24, top: 30, bottom: 0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            DropdownButtonFormField(
              items: _prodcutSizeList
                  .map((e) => DropdownMenuItem(
                        child: Text(e),
                        value: e,
                      ))
                  .toList(),
              onChanged: (val) {
                setState(() {
                  _slectedValue = val as String;
                });
              },
              icon: const Icon(
                Icons.arrow_drop_down_circle,
                color: Colors.blue,
              ),
              dropdownColor: Colors.blue.shade50,
              decoration: InputDecoration(
                prefixIcon:
                    const Icon(Icons.production_quantity_limits_rounded),
                labelText: "Select Product",
                border: const OutlineInputBorder(),
              ),
            ),
            const SizedBox(height: 16),
            DropdownButtonFormField(
              items: _prodcutSizeList
                  .map((e) => DropdownMenuItem(
                        child: Text(e),
                        value: e,
                      ))
                  .toList(),
              onChanged: (val) {
                setState(() {
                  _slectedValue = val as String;
                });
              },
              icon: const Icon(
                Icons.arrow_drop_down_circle,
                color: Colors.blue,
              ),
              dropdownColor: Colors.blue.shade50,
              decoration: InputDecoration(
                prefixIcon: const Icon(Icons.numbers),
                labelText: "Quntity",
                border: const OutlineInputBorder(),
              ),
            ),
            const SizedBox(height: 16),
            DropdownButtonFormField(
              items: _prodcutSizeList
                  .map((e) => DropdownMenuItem(
                        child: Text(e),
                        value: e,
                      ))
                  .toList(),
              onChanged: (val) {
                setState(() {
                  _slectedValue = val as String;
                });
              },
              icon: const Icon(
                Icons.arrow_drop_down_circle,
                color: Colors.blue,
              ),
              dropdownColor: Colors.blue.shade50,
              decoration: InputDecoration(
                prefixIcon: const Icon(Icons.cabin),
                labelText: "Supplier",
                border: const OutlineInputBorder(),
              ),
            ),
            const SizedBox(height: 16),
            TextFormField(
                controller: null,
                //editing controller of this TextField
                decoration: const InputDecoration(
                    border: const OutlineInputBorder(),
                    prefixIcon: Icon(Icons.calendar_today), //icon of text field
                    labelText: "Delivery Date" //label text of field
                    ),
                readOnly: true, // when true user cannot edit text
                onTap: () async {
                  //when click we have to show the datepicker
                }),
            const SizedBox(height: 16),
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                onPressed: () {
                  widget.saveOrder(widget.userNameController.text,
                      widget.passwordController.text);
                },
                child: const Text("Order"),
              ),
            )
          ],
        ),
      ),
    );
  }
}
