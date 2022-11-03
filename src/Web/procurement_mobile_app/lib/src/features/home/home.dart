import 'package:flutter/material.dart';
import 'package:procurement_mobile_app/src/common_widgets/bottom_navigation_view/bottom_bar_view.dart';
import 'package:procurement_mobile_app/src/features/authentication/authentication.screen.dart';
import 'package:procurement_mobile_app/src/features/common_dashboard/common_dashboard.dart';
import 'package:procurement_mobile_app/src/features/order/save.order.screen.dart';
import 'package:procurement_mobile_app/src/features/procurement_app_theme.dart';
import 'package:procurement_mobile_app/src/models/tabIcon_data.dart';

class AppModuleScreen extends StatefulWidget {
  @override
  _AppModuleScreenState createState() => _AppModuleScreenState();
}

class _AppModuleScreenState extends State<AppModuleScreen>
    with TickerProviderStateMixin {
  AnimationController? animationController;

  List<TabIconData> tabIconsList = TabIconData.tabIconsList;

  Widget tabBody = Container(
    color: ProcurementAppTheme.background,
  );

  @override
  void initState() {
    tabIconsList.forEach((TabIconData tab) {
      tab.isSelected = false;
    });
    tabIconsList[0].isSelected = true;

    animationController = AnimationController(
        duration: const Duration(milliseconds: 600), vsync: this);
    tabBody = SaveOrderScreen(animationController: animationController);
    super.initState();
  }

  @override
  void dispose() {
    animationController?.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      color: ProcurementAppTheme.background,
      child: Scaffold(
        backgroundColor: Colors.transparent,
        body: FutureBuilder<bool>(
          future: getData(),
          builder: (BuildContext context, AsyncSnapshot<bool> snapshot) {
            if (!snapshot.hasData) {
              return const SizedBox();
            } else {
              return Stack(
                children: <Widget>[
                  tabBody,
                  //bottomBar(),
                ],
              );
            }
          },
        ),
      ),
    );
  }

  Future<bool> getData() async {
    await Future<dynamic>.delayed(const Duration(milliseconds: 200));
    return true;
  }

  Widget bottomBar() {
    return Column(
      children: <Widget>[
        const Expanded(
          child: SizedBox(),
        ),
        BottomBarView(
          tabIconsList: tabIconsList,
          addClick: () {},
          changeIndex: (int index) {
            if (index == 0 || index == 2) {
              animationController?.reverse().then<dynamic>((data) {
                if (!mounted) {
                  return;
                }
                setState(() {
                  tabBody =
                      CommonDashboard(animationController: animationController);
                });
              });
            } else if (index == 1 || index == 3) {
              animationController?.reverse().then<dynamic>((data) {
                if (!mounted) {
                  return;
                }
                setState(() {
                  tabBody =
                      CommonDashboard(animationController: animationController);
                });
              });
            }
          },
        ),
      ],
    );
  }
}
