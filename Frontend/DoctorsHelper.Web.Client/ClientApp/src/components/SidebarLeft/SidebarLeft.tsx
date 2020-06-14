import * as React from "react";
import styles from "./SidebarLeft.module.css";
import {Layout, Menu} from "antd";
import {
    CalculatorOutlined,
    ReadOutlined,
    LineChartOutlined,
} from "@ant-design/icons";
import {useState} from "react";
import {Link} from "react-router-dom";

const {Sider} = Layout;
const {SubMenu} = Menu;

const SidebarLeft = () => {
    const [isCollapsed, setIsCollapsed] = useState(false);

    return (
        <div className={styles.sidebar}>
            <Layout>
                <Sider

                    collapsible
                    collapsed={isCollapsed}
                    onCollapse={() => setIsCollapsed(!isCollapsed)}
                >
                    <div className="logo"/>
                    <Menu mode="inline" className={styles.menu} style={{overflow: 'auto'}}>
                        <SubMenu
                            key="imt"
                            icon={<CalculatorOutlined translate={undefined}/>}
                            title="Идеальная масса тела"
                        >
                            <Menu.Item key="imt_1">
                                <Link to="/IndexSolovieva">Индекс Соловьева</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_2">
                                <Link to="/LorentzFormula">Формула Лоренца</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_3">
                                <Link to="/IndexBroka">Индекс Брока</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_4">
                                <Link to="/IndexBrokaBruksha">Индекс Брока-Бругша</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_5">
                                <Link to="/CuperFormula">Формула Купера</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_6">
                                <Link to="/IndexBorngardt">Индекс Борнгардта</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_7">
                                <Link to="/DevinFormula">Формула Девина</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_8">
                                <Link to="/EgorovaTable">Таблица Егорова-Левитского</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_9">
                                <Link to="/MillerFormula">Формула Миллера</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_10">
                                <Link to="/KreffFormula">Формула Креффа</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_11">
                                <Link to="/NaglerFormula">Формула Наглера</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_12">
                                <Link to="/MochammedFormula">Формула Моххамеда</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_13">
                                <Link to="/RobinsonFormula">Формула Робинсона</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_14">
                                <Link to="/MonnerotFormula">Формула Моннерота-Думайна</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_15">
                                <Link to="/HamviFormula">Формула Хамви</Link>
                            </Menu.Item>
                            <Menu.Item key="imt_16">
                                <Link to="/General">Общий калькулятор</Link>
                            </Menu.Item>
                        </SubMenu>
                        <SubMenu
                            key="imt1"
                            icon={<CalculatorOutlined translate={undefined}/>}
                            title="Медицинские калькуляторы"
                        >
                            <Menu.Item key="mc_1">
                                <Link to="/IMT">Индекс массы тела</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_2">
                                <Link to="/Score">Шкала SCORE</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_3">
                                <Link to="/Timi">Шкала TIMI</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_4">
                                <Link to="/CHA2DS2VASc">Шкала CHA2DS2VASc</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_5">
                                <Link to="/HASBLED">Шкала HAS-BLED</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_6">
                                <Link to="/KIN">Вероятность развития КИН</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_7">
                                <Link to="/GRACE">Шкала GRACE</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_8">
                                <Link to="/GlomerularFiltrationRate">СКФ и КК</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_9">
                                <Link to="/IndexSmoke">Индекс курения</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_10">
                                <Link to="/CorrectedQTCalculation">Расчет корригированного QT</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_11">
                                <Link to="/InfusionRate">Расчет скорости инфузии</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_12">
                                <Link to="/PotassiumDeficiency">Расчет дефицита калия</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_13">
                                <Link to="/SubstanceinSolution">Расчет вещества в растворе</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_14">
                                <Link to="/Glasgo">Шкала комы Глазго</Link>
                            </Menu.Item>
                            <Menu.Item key="mc_15">
                                <Link to="/AntihypertensiveTherapy">Подбор гипотензивной терапии</Link>
                            </Menu.Item>
                        </SubMenu>
                        <SubMenu
                            key="dict"
                            icon={<ReadOutlined translate={undefined}/>}
                            title="Справочники">
                            <Menu.Item key="dict_1">
                                <Link to="/Order302N">Приказ 302н</Link>
                            </Menu.Item>
                            <Menu.Item key="dict_2">
                                <Link to="/GeneralMedicalContraindication">Перечень общих медицинских
                                    противопоказаний</Link>
                            </Menu.Item>
                            <Menu.Item key="dict_4">
                                <Link to="/Mkb10">МКБ 10</Link>
                            </Menu.Item>
                            <Menu.Item key="dict_3">
                                <Link to="/Order417N">Приказ 417-н</Link>
                            </Menu.Item>
                        </SubMenu>
                        <SubMenu
                            key="arterialPressure"
                            icon={<LineChartOutlined />}
                            title="Дневник АД"
                        >
                            <Menu.Item key="arterialPressure_1">
                                <Link to="/ArterialPressure">Главная</Link>
                            </Menu.Item>
                            <Menu.Item key="arterialPressure_2">
                                <Link to="/AddNote">Внесение записей</Link>
                            </Menu.Item>
                            <Menu.Item key="arterialPressure_3">
                                <Link to="/ViewRecords">Просмотр записей</Link>
                            </Menu.Item>

                        </SubMenu>
                    </Menu>
                </Sider>
            </Layout>
        </div>
    );
}

export default SidebarLeft;
