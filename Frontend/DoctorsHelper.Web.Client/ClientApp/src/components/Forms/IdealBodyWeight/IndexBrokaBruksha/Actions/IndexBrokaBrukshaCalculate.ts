import {IResult, IErrors} from "../../../../../common/Interfaces";
import {
    IndexBrokaBrukshaResponse,
    IndexBrokaBrukshaClient
} from "../../../../../apiClient/apiClient";
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function IndexBrokaBrukshaCalculate(height: number) {
    let res: IResult<IndexBrokaBrukshaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new IndexBrokaBrukshaClient(getAuthClient());
        res.result = await client.calculate(height);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}