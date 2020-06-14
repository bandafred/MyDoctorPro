import * as React from "react";
import {Row, Col, Table, Button, Divider, Radio, Input} from "antd";
import styles from "./Order417N.module.css";
import {useState} from "react";
import DictionaryPageTitleArray from "../../FormsComponets/DictionaryPageTitle/DictionaryPageTitleArray";
import {Order417NResponse} from "../../../../apiClient/apiClient";
import {IResult} from "../../../../common/Interfaces";
import Column from "antd/lib/table/Column";
import {GetOrder417NRecords} from "./Actions/GetOrder417NRecords";

const {Search} = Input;

const Order417N = () => {

    let def: IResult<Order417NResponse> = {
        error: undefined,
        result: undefined,
    };

    const [result, setResult] = useState(def);
    const [isLoad, setIsLoad] = useState(false);

    const loadData = async (searchText: string | null | undefined) => {
        setIsLoad(true);
        setResult(await GetOrder417NRecords(searchText));
        setIsLoad(false);
    };

    React.useEffect(() => {
        loadData('');
    }, []);

    return (
        <Row className={styles.wrap}>
            <Col span={24}>
                <DictionaryPageTitleArray
                    name={"Приказ 417-н об утверждении перечня профессиональных заболеваний"}
                    description={[
                        "Приказа Минздравсоцразвития России от 27.04.2012 N 417н \"Об утверждении перечня профессиональных заболеваний\" (Зарегистрировано в Минюсте России 15.05.2012 N 24168)",
                    ]}
                />
            </Col>

            <Col xl={24}>
                <Search
                    placeholder="Поиск..."
                    enterButton="Поиск"
                    size="large"
                    onSearch={value => loadData(value)}
                />
            </Col>

            <Col xl={24}>
                <Table dataSource={result?.result?.records} loading={isLoad} pagination={false}
                       rowKey={x => x.point ?? "" + x.nosology + x.codeNosology + x.dangerFactor + x.codeExternal}>
                    <Column title="Пункт" dataIndex="point" key="point"/>
                    <Column
                        title="Перечень заболеваний, связанных с воздействием вредныйх и (или) опасных производственных факторов"
                        dataIndex="nosology" key="nosology"/>
                    <Column
                        title="Код заболевания по МБК-10"
                        dataIndex="codeNosology"
                        key="codeNosology"
                        render={codeNosology => (
                            <ul>
                                {codeNosology.split("#").filter((x: string) => x !== "").map((code: string) =>
                                    <li>
                                        {code}
                                    </li>)}
                            </ul>
                        )}
                    />
                    <Column title="Наименование вредного и (или) опасного производственного фактора"
                            dataIndex="dangerFactor" key="dangerFactor"/>
                    <Column title="Код внешней причины по МБК-10" dataIndex="codeExternal" key="codeExternal"/>
                </Table>
            </Col>
        </Row>
    );
};
export default Order417N;
