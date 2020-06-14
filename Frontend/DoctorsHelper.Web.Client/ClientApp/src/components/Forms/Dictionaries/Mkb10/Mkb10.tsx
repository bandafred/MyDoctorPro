import * as React from "react";
import { Row, Col, Table, Button, Divider, Radio, Input } from "antd";
import styles from "./Mkb10.module.css";
import { useState } from "react";
import DictionaryPageTitleArray from "../../FormsComponets/DictionaryPageTitle/DictionaryPageTitleArray";
import { Mkb10Response } from "../../../../apiClient/apiClient";
import { IResult } from "../../../../common/Interfaces";
import Column from "antd/lib/table/Column";
import { TablePaginationConfig } from "antd/lib/table";
import {GetMkb10Records} from "./Actions/GetMkb10Records";

const { Search } = Input;

const Mkb10 = () => {
    let pageSizeDefault = 10;
    let pageDefault = 1;
    let def: IResult<Mkb10Response> = {
        error: undefined,
        result: undefined,
    };

    const [page, setPage] = useState(pageDefault);

    const [result, setResult] = useState(def);
    const [isLoad, setIsLoad] = useState(false);
    const [searchText, setSearchText] = useState("");

    const loadData = async (search: string,  skipCount: number | undefined, takeCount: number | undefined) => {
        setIsLoad(true);
        setResult(await GetMkb10Records(search, skipCount, takeCount));
        setIsLoad(false);
    };
    
    const onSearch = (val: string) =>{
        setSearchText(val);
        setPage(1);
        loadData(val,0, pageSizeDefault)
    }

    React.useEffect(() => {
        loadData(searchText, 0, pageSizeDefault);
    }, []);

    React.useEffect(() => {
        loadData(searchText, page * pageSizeDefault, pageSizeDefault);
        
        console.log(page)
    }, [page]);

    let pagination: TablePaginationConfig = {
        current: page,
        pageSize: pageSizeDefault,
        onChange: setPage,
        showSizeChanger: false,
        //TODO: Почему то считает на страницу больше, видимо ошибка в antd
        total: (result?.result?.totalCount ?? 0) - pageSizeDefault
    }

    return (
        <Row className={styles.wrap}>
            <Col span={24}>
                <DictionaryPageTitleArray
                    name={"МКБ 10"}
                    description={[
                        "Международная классификация болезней десятого пересмотра",
                    ]}
                />
            </Col>

            <Col xl={24}>
                <Search
                    placeholder="Поиск..."
                    enterButton="Поиск"
                    size="large"
                    onSearch={value => onSearch(value)}
                />
            </Col>

            <Col xl={24}>
                <Table dataSource={result?.result?.records} loading={isLoad} pagination={pagination} rowKey={x => x.code ?? "" + x.name}>
                    <Column title="Код" dataIndex="code" key="code" />
                    <Column title="Нозология" dataIndex="name" key="name" />
                </Table>
            </Col>
        </Row>
    );
};
export default Mkb10;
