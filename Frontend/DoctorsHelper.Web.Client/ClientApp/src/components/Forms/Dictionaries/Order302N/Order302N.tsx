import * as React from "react";
import {Row, Col, Table, Button, Divider, Radio, Input} from "antd";
import styles from "./Order302N.module.css";
import {useState} from "react";
import DictionaryPageTitleArray from "../../FormsComponets/DictionaryPageTitle/DictionaryPageTitleArray";
import {Order302NResponse} from "../../../../apiClient/apiClient";
import {IResult} from "../../../../common/Interfaces";
import Column from "antd/lib/table/Column";
import {Order302NResponseRecord} from "../../../../apiClient/apiClient";
import {getOrder302NRecords} from "./Actions/getOrder302NRecords";

const {Search} = Input;

const Order302N = () => {
    let applicationItemNumberDefault = 1;
    let def: IResult<Order302NResponse> = {
        error: undefined,
        result: undefined,
    };
    let recordsDefault: Order302NResponseRecord[] = [];

    const [records, setRecords] = useState(recordsDefault);

    const [result, setResult] = useState(def);
    const [isLoad, setIsLoad] = useState(false);
    const [isFirstAttachment, setFirstAttachment] = useState(true);

    const loadData = async (searchText: string | null | undefined, number?: number | undefined) => {
        setIsLoad(true);
        let applicationItemNumber = 1;
        if(!number) applicationItemNumber = isFirstAttachment ? 1 : 2;
        if(number) applicationItemNumber = number;
        var res = await getOrder302NRecords(searchText);
        setResult(res);
        if (res && res.result && res.result.records)
            setRecords(res.result.records.filter(x => x.applicationItemNumber == applicationItemNumber));
        setIsLoad(false);
    };

    const handleApplicationItemNumberChange = (applicationItemNumber: number) => {
        if (applicationItemNumber == 1) setFirstAttachment(true);
        if (applicationItemNumber == 2) setFirstAttachment(false);
        loadData('', applicationItemNumber);
        // if (result && result.result && result.result.records)
        //     setRecords(result.result.records.filter(x => x.applicationItemNumber == applicationItemNumber))
    }

    React.useEffect(() => {
        loadData('');
    }, []);

    return (
        <Row className={styles.wrap}>
            <Col span={24}>
                <DictionaryPageTitleArray
                    name={"Приказ Минздравсоцразвития России от 12.04.2011 N 302н (ред. от 13.12.2019)"}
                    description={[
                        "\"Об утверждении перечней вредных и (или) опасных производственных факторов и работ, при выполнении которых проводятся обязательные предварительные и периодические медицинские осмотры (обследования), и  орядка проведения обязательных предварительных и периодических медицинских осмотров (обследований) работников, занятых на тяжелых работах и на работах с вредными и (или) опасными условиями труда\" (Зарегистрировано в Минюсте России 21.10.2011 N 22111)",
                    ]}
                />
            </Col>

            <Col xl={24}>
                <div style={{textAlign: "center"}}>
                    <Button type={isFirstAttachment ? "primary" : "link"}
                            onClick={() => handleApplicationItemNumberChange(1)} style={{margin: 20}}>Приложение
                        1</Button>
                    <Button type={!isFirstAttachment ? "primary" : "link"}
                            onClick={() => handleApplicationItemNumberChange(2)} style={{margin: 20}}>Приложение
                        2</Button>
                </div>
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
                <Table dataSource={records} loading={isLoad} pagination={false}
                       rowKey={x => x.point ?? "" + x.name + x.inspectionFrequency + x.additionalMedicalContraindications}>
                    <Column title="Пункт" dataIndex="point" key="point"/>
                    <Column title="Наименование вредных и(или) опасных производственных факторов" dataIndex="name"
                            key="name"/>
                    <Column title="Периодичность осмотров Участие врачей-специалистов" dataIndex="inspectionFrequency"
                            key="inspectionFrequency"/>
                    <Column title="Дополнительные медицинские противопоказания"
                            dataIndex="additionalMedicalContraindications" key="additionalMedicalContraindications"/>
                </Table>
            </Col>
        </Row>
    );
};
export default Order302N;
