import {IResult, IErrors} from "../../../../../common/Interfaces";
import {IndexBrokaResponse, IndexBrokaClient} from "../../../../../apiClient/apiClient";
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function IndexBrokaCalculate(height: number, isMan: boolean) {
    let res: IResult<IndexBrokaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new IndexBrokaClient(getAuthClient());
        res.result = await client.calculate(height, isMan);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}