import * as React from "react";
import { Row, Col, Table, Button, Divider, Radio, Input } from "antd";
import styles from "./GeneralMedicalContraindication.module.css";
import { useState } from "react";
import DictionaryPageTitleArray from "../../FormsComponets/DictionaryPageTitle/DictionaryPageTitleArray";
import { GeneralMedicalContraindicationResponse } from "../../../../apiClient/apiClient";
import { IResult } from "../../../../common/Interfaces";
import Column from "antd/lib/table/Column";
import {GetGeneralMedicalContraindicationRecords} from "./Actions/GetGeneralMedicalContraindicationRecords";

const { Search } = Input;

const GeneralMedicalContraindication = () => {
    
    let def: IResult<GeneralMedicalContraindicationResponse> = {
        error: undefined,
        result: undefined,
    };

    const [result, setResult] = useState(def);
    const [isLoad, setIsLoad] = useState(false);

    const loadData = async (searchText: string | null | undefined) => {
        setIsLoad(true);
        setResult(await GetGeneralMedicalContraindicationRecords(searchText));
        setIsLoad(false);
    };

    React.useEffect(() => {
        loadData('');
    }, []);

    return (
        <Row className={styles.wrap}>
            <Col span={24}>
                <DictionaryPageTitleArray
                    name={"Перечень общих медицинских противопоказаний"}
                    description={[
                        "Перечень общих медицинских противопоказаний к допуску на работы с вредными и (или) опасными производственными факторами, а также к работам, при выполнении которых обязательно проведение предварительных и периодических медицинских осмотров (обследований) работников",
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
                <Table dataSource={result?.result?.records} loading={isLoad} pagination={false} rowKey={x => x.id } >
                    <Column title="Пункт" dataIndex="id" key="id" />
                    <Column title="Патология" dataIndex="pathology" key="pathology" />
                </Table>
            </Col>
        </Row>
    );
};
export default GeneralMedicalContraindication;
