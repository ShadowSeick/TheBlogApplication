let index = 0;

function AddTag() {
    let tagEntry = document.getElementById("TagEntry");
    let tagList = document.getElementById("TagList");
    

    //Use the search function to help detect an error state

    let searchResult = SearchTagAndReturnErrorString(tagEntry.value);

    if (searchResult) {
        //Trigger sweet alert
        swalWithDarkButton.fire({
            html: `<span class = "fw-bolder">${searchResult.toUpperCase()}</span>`
        })
    }
    else {
        //Create a new Select Option
        let newOption = new Option(tagEntry.value, tagEntry.value);
        tagList.options[index++] = newOption;
    }
  
    //Clear out the TagEntry control
    tagEntry.value = "";
    return true;

}

function DeleteTag() {
    //Only can delete if there is a tag selected
    let tagCount = 1;
    let tagList = document.getElementById("TagList");

    if (!tagList) return false;

    if (tagList.selectedIndex === -1) {
        swalWithDarkButton.fire({
            html: `<span class = "fw-bolder text-uppercase">choose a tag before deleting</span>`
        });
        return true;
    }

    while (tagCount > 0) {
        if (tagList.selectedIndex >= 0) {
            tagList.options[tagList.selectedIndex] = null;
            --tagCount;
        }
        else {
            tagCount = 0;
        }
        index--;
    }
}

$("form").on("submit", function () {
    $("#TagList option").prop("selected", "selected");
})

//Look for the tagvalues variable to see if it has data

if (tagValues !== "") {
    let tagArray = tagValues.split(",");
    for (let i = 0; i < tagArray.length; i++) {
        //Load up or replace the options that we have
        ReplaceTag(tagArray[i], i);
        index++;
    }
}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
}

function SearchTagAndReturnErrorString(str) {
    if (!str) {
        return "Empty tags are not permitted";
    }

    let tagsElement = document.getElementById("TagList");
    if (tagsElement) {
        let options = tagsElement.options;
        for (let i = 0; i < options.length; i++) {
            if (options[i].value === str) return `The Tag #${str} was not allowed. Duplicate Tags are not permitted.`;
        }
    }
}

const swalWithDarkButton = Swal.mixin({
    customClass: {
        confirmButton: "btn btn-danger btn-sm btn-outline-dark w-75"
    },
    imageUrl: "/img/NotAllowed.jpg",
    timer: 3000,
    buttonsStyling: false
})